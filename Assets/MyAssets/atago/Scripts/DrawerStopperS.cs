using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerStopperS : MonoBehaviour {

    private void Update()
    {
        Debug.Log(transform.localPosition);
    }
    private void OnTriggerStay(Collider collision)
    {
        if(collision.gameObject.CompareTag("Stopper") && transform.localPosition.x < 0.0345)
        {
            GetComponent<DrawerMove>().enabled = false;

            Vector3 pos = transform.localPosition;
            pos.x = 0.0345f;
            transform.localPosition = pos;

            GetComponent<DrawerMove>().enabled = true;
        }

        if(collision.gameObject.CompareTag("Stopper") && transform.localPosition.x > 0.455)
        {
            GetComponent<DrawerMove>().enabled = false;

            Vector3 pos = transform.localPosition;
            pos.x = 0.455f;
            transform.localPosition = pos;

            GetComponent<DrawerMove>().enabled = true;
        }
    }
}
