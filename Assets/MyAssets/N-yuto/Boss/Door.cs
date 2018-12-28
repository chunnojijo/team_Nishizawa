using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    [SerializeField] GameObject RespawnPoint;
    [SerializeField] Light[] lights;
    [SerializeField] GameObject SOTO;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            StartCoroutine("GameOver", other.gameObject);

        }

    }

    private IEnumerator GameOver(GameObject player)
    {

        DarknessCtrl.ChangeState(DarknessCtrl.State.ChangeToDark, 0.5f);
        yield return new WaitForSeconds(1);
        player.transform.position = RespawnPoint.transform.position;
       
        for(int i = 0; i<lights.Length; i++)
        {
            lights[i].enabled = false;
        }

        SOTO.SetActive(true);
        
        yield return new WaitForSeconds(1);
        DarknessCtrl.ChangeState(DarknessCtrl.State.ChangeToClear);

    }
}
