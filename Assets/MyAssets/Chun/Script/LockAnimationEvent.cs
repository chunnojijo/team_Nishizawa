using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockAnimationEvent : MonoBehaviour {
    private AudioSource[] audiosource;
	// Use this for initialization
	void Start () {
        audiosource = GetComponents<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void keyOpen()
    {
        audiosource[0].Play();
    }
    private void jouOpen()
    {
        audiosource[1].Play();
    }
}
