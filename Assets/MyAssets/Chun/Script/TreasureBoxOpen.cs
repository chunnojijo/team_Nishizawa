using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureBoxOpen : MonoBehaviour {
    public float keyspeed = .0f;
    [SerializeField]
    private GameObject Ghost;
    [SerializeField]
    private GameObject Aura;
    [SerializeField]
    private GameObject key;
    private bool first = true;
    private float time = 0;
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
                key.GetComponent<Animator>().SetTrigger("KeyFloat");
            }
            if (key.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("New State")) key.GetComponent<Animator>().enabled = false;
            //if(time<2)key.transform.position += new Vector3(-keyspeed * Time.deltaTime, 0, 0);
            //time += Time.deltaTime;
        }
	}
}
