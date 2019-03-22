using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGravity : MonoBehaviour {
    public GameObject obj;

    void OnGrav()
    {
        obj.GetComponent<Rigidbody>().useGravity = true;
    }

    void OffGrav()
    {
        obj.GetComponent<Rigidbody>().useGravity = false;
    }
}