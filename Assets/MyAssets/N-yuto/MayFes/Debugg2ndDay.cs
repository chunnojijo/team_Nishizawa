using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugg2ndDay : MonoBehaviour {

    [SerializeField] GameObject keyprefab;
    [SerializeField] GameObject hmd;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKeyDown("k") && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            DropKey();
        }
        if (Input.GetKeyDown("r") && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            GrabRelease.ReleaseAllObjects();
        }
        if (Input.GetKeyDown("o") && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {

        }
        if (Input.GetKeyDown("o") && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {

        }
        if (Input.GetKeyDown("o") && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {

        }

    }

     void DropKey()
    {
        Instantiate(keyprefab,hmd.transform.position - hmd.transform.forward * 3,keyprefab.transform.rotation);
        Debug.LogWarning("key");
    }

}
