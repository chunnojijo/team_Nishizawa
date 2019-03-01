using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSound : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (this.GetComponent<Torchelight>().IntensityLight > 0)
        {
            this.GetComponent<AudioSource>().volume = 0.385f;
        }
	}
}
