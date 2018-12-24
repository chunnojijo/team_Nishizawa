using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCtrl : MonoBehaviour {

    [SerializeField] GameObject RespawnPoint;

	// Use this for initialization
	void Start () {
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
        yield return new WaitForSeconds(1);
        DarknessCtrl.ChangeState(DarknessCtrl.State.ChangeToClear);

    } 



}
