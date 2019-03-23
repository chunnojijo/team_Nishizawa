using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerLocker : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<DrawerMove>().enabled == false)
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
        else
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        }
	}
}
