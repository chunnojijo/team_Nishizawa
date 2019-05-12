using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor2 : MonoBehaviour
{

    public GameObject door;
    Animator animator;

    void Start()
    {
        animator = door.GetComponent<Animator>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.Play("Door2Close");
            gameObject.SetActive(false);
        }
    }
}
