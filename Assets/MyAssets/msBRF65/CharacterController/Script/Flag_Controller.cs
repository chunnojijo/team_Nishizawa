using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag_Controller : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("痛い！！");
    }

}

