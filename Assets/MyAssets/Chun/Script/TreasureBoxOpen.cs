using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureBoxOpen : MonoBehaviour {

    [SerializeField]
    private GameObject Ghost;
    [SerializeField]
    private GameObject Aura;
    private bool first = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Ghost.GetComponent<Escape>().dieatall)
        {
            Aura.GetComponent<ParticleSystem>().Stop();
            this.GetComponent<Animator>().SetBool("Open", true);
            if (first)
            {
                this.GetComponent<AudioSource>().Play();
                first = false;
            }
        }
	}
}
