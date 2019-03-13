using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabinet : MonoBehaviour {

    [SerializeField]
    private  GameObject Switch;
    private bool first = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Switch.gameObject.GetComponent<SwitchPush>().doorOpen)
        {
            this.GetComponent<Animator>().SetTrigger("Open");
            
            if (first)
            {
                first = false;
                this.GetComponent<AudioSource>().Play();
            }
        }
        
            
	}

}
