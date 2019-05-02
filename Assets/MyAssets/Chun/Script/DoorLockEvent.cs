using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLockEvent : MonoBehaviour {

    [SerializeField] private GameObject Door;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Door.GetComponent<Animator>().SetTrigger("DoorLock");
        this.GetComponent<AudioSource>().Play();
    }
}
