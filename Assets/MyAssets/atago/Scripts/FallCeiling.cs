using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallCeiling : MonoBehaviour {

    public GameObject[] falls;
    public GameObject[] ghosts;
    public GameObject door;
    Animator animator;

    // Use this for initialization
    void Start()
    {
        for(int i=0; i<falls.Length; i++)
        {
            falls[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }

        animator = door.GetComponent<Animator>();

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            for(int i=0; i<falls.Length; i++)
            {
                falls[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            }

            Invoke("GhostAppear", 2f);

            gameObject.SetActive(false);
        }
    }

    void GhostAppear()
    {
        for (int i = 0; i < ghosts.Length; i++)
        {
            ghosts[i].GetComponent<Escape>().appear = true;
        }

        animator.Play("Door3Close");

    }
}
