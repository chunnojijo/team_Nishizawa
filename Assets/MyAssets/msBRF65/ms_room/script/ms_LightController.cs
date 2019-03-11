﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ms_LightController : MonoBehaviour {
    private bool lock_light = true;

	// Use this for initialization
	void Start () {
        this.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(lock_light == false)
        {
            this.gameObject.SetActive(true);
        }
	}

    public void UnLock()
    {
        lock_light = false;
    }
}
