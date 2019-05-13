using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLockEvent : MonoBehaviour {

    [SerializeField] private GameObject Door;
    //private bool first=true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player"/*&&first*/)
        {

            Door.GetComponent<Animator>().SetTrigger("DoorClose");
            Door.GetComponent<AudioSource>().Play();
            
            DoorLockEvent[] doorLockEvents = transform.parent.GetComponentsInChildren<DoorLockEvent>();
            foreach(DoorLockEvent o in doorLockEvents){
                o.gameObject.SetActive(false);
            }
            
            //first=false;
        }
    }
}
