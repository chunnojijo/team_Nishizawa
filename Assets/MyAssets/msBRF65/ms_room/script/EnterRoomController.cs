﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterRoomController : MonoBehaviour {
    public GameObject obake1, obake2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}
    void OnTriggerEnter(Collision Other)
    {
        if (Other.gameObject.tag == "player")
        {
            OVRDebugConsole.Log("collision");
            obake1.SetActive(true);
            obake2.SetActive(true);
        }
    }
}
