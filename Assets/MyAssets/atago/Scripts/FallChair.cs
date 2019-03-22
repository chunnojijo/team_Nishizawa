using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallChair : MonoBehaviour
{

    public GameObject chair;
    Animator animator;

    void Start()
    {
        animator = chair.GetComponent<Animator>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.Play("ChairFall");
            gameObject.SetActive(false);
        }
    }
}
