using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour {
    

    private Animator animator;
    [SerializeField]
    private GameObject key;
    [SerializeField]
    private GameObject player;
	// Use this for initialization
	void Start () {
        animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        /*if (key.GetComponent<Key>().getstatus&&(player.transform.root.transform.position-this.transform.position).magnitude<1)
        {
            animator.SetBool("Open", true);
        }*/
	}

    private void OnTriggerEnter(Collider other)
    {
        if (key.GetComponent<Key>().getstatus)
        {
            animator.SetBool("DoorOpen", true);
        }
    }
}
