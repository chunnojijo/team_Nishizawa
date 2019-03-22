using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallCeiling : MonoBehaviour {

    public GameObject[] falls;
    public GameObject[] walls;
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

            Invoke("CreateWall", 2f);

            gameObject.SetActive(false);
        }
    }

    void CreateWall()
    {
        for (int i = 0; i < walls.Length; i++)
        {
            walls[i].SetActive(true);
        }

        animator.Play("Door3Close");

    }
}
