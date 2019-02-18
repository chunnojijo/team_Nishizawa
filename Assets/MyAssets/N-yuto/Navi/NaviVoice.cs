using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaviVoice : MonoBehaviour {

    [SerializeField] AudioSource source;

    [SerializeField] AudioClip[] clips ;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Play(int ClipNumber)
    {
        if(ClipNumber >= clips.Length || ClipNumber < 0) { return; }

        source.PlayOneShot(clips[ClipNumber]);
    }

}
