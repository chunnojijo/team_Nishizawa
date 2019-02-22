using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallCeiling : MonoBehaviour {

    public GameObject[] objects;

    // Use this for initialization
    void Start()
    {
        for(int i=0; i<objects.Length; i++)
        {
            objects[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            for(int i=0; i<objects.Length; i++)
            {
                objects[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            }

            gameObject.SetActive(false);
        }
    }
}
