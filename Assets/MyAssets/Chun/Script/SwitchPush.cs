using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPush : MonoBehaviour {

    public bool doorOpen = false;
    public float doorOpentime = 1.35f;
    private bool push = false;
    private float time = 0;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.B))
        {
            this.GetComponent<Animator>().SetTrigger("Push");
            push = true;
        }
        if (push)
        {
            time += Time.deltaTime;
            if (time > doorOpentime)
            {
                doorOpen = true;
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "PlayerHand")
        {
            this.GetComponent<Animator>().SetTrigger("Push");
            push = true;
        }
    }
}
