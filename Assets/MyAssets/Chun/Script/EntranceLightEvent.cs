using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceLightEvent : MonoBehaviour {

    [SerializeField]
    private GameObject Light_For_Debug;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Light_For_Debug.GetComponent<Animator>().SetBool("Play", true);
        }
    }
}
