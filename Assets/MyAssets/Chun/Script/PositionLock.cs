using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionLock : MonoBehaviour {

    private Transform transformThis;
    
	// Use this for initialization
	void Start () {
        transformThis = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = transformThis.position;
        this.transform.rotation = transformThis.rotation;
	}
}
