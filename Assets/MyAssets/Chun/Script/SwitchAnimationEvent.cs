using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAnimationEvent : MonoBehaviour {

    private AudioSource audiosource;
	// Use this for initialization
	void Start () {
        audiosource = GetComponent<AudioSource>();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SwitchPush()
    {
        audiosource.Play();
    }
}
