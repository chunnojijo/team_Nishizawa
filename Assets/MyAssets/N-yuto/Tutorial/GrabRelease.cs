using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabRelease : MonoBehaviour {

    static OVRGrabber[] grabbers;

	// Use this for initialization
	void Start () {
        if (grabbers == null)
        {
            grabbers = FindObjectsOfType<OVRGrabber>();
        }	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void ReleaseAllObjects()
    {
        for(int i = 0; i< grabbers.Length; i++)
        {
            grabbers[i].GrabEnd();
        }
    }
}
