using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostDeathSensor : MonoBehaviour {

    Escape escape;
    [SerializeField] GameObject key;
    
	// Use this for initialization
	void Start () {
        escape = gameObject.GetComponent<Escape>();
		
	}
	
	// Update is called once per frame
	void Update () {
        if (escape.dieatall)
        {
            key.SetActive(true);
        }
	}



}
