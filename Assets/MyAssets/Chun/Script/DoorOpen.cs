using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{

    private bool first = true;
    private bool open = false;
    private Animator animator;
    [SerializeField]
    private GameObject Lock;
    /*[SerializeField]
    private GameObject key;
    [SerializeField]
    private GameObject player;*/
    // Use this for initialization
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (key.GetComponent<Key>().getstatus&&(player.transform.root.transform.position-this.transform.position).magnitude<1)
        {
            animator.SetBool("Open", true);
        }*/
        if (Input.GetKeyDown(KeyCode.Space))
        {

            open = true;
        }
        if (open)
        {
            Lock.GetComponent<Animator>().SetTrigger("Open");
            if (first)
            {
                first = false;

            }
            else
            {
                if (!Lock.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Open"))
                {
                    GetComponent<Animator>().SetBool("DoorOpen", true);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Key")
        {
            open = true;
            Destroy(other);
        }
    }
}
