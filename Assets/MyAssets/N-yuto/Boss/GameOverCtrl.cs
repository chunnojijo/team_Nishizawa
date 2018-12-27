using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCtrl : MonoBehaviour {

    [SerializeField] GameObject RespawnPoint;
    [SerializeField] GameObject CabinettPrefab;

    GameObject newCabinett;
    GameObject cabinett;

    Vector3 pos = new Vector3 (-12.23f,0.34f,2.08f);
    Quaternion rot = Quaternion.Euler(0f, -204.65f, 0f);

    public static int Num = 1;


    // Use this for initialization
    void Start () {

        cabinett = transform.parent.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        
		
	}

    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag == "Player")
        {
            StartCoroutine("GameOver",other.gameObject);

        }

    }
    
    private IEnumerator GameOver(GameObject player)
    {

        DarknessCtrl.ChangeState(DarknessCtrl.State.ChangeToDark, 0.5f);
        yield return new WaitForSeconds(1);
        player.transform.position = RespawnPoint.transform.position;
        iTween.Stop(transform.parent.gameObject);
        Debug.Log("1");
        cabinett.transform.position = new Vector3(0f, -100f, 0f);
        yield return new WaitForSeconds(1);
        Debug.Log("11");
        DarknessCtrl.ChangeState(DarknessCtrl.State.ChangeToClear);
        ChangePathName(CabinettPrefab);
        Debug.Log("111");
        newCabinett = Instantiate(CabinettPrefab,pos,rot);
        Debug.Log("1111");
        Destroy(cabinett);

    } 

    void ChangePathName(GameObject cabinett)
    {
        Num += 1;
        iTweenPath path = cabinett.GetComponentInChildren<iTweenPath>();
        string newName = "BossPath" + Num.ToString();
        path.pathName = newName;
    }

}
