using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerStopperL : MonoBehaviour
{

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Stopper") && transform.localPosition.x < -0.085)
        {
            GetComponent<DrawerMove>().enabled = false;

            Vector3 pos = transform.localPosition;
            pos.x = -0.085f;
            transform.localPosition = pos;

            GetComponent<DrawerMove>().enabled = true;
        }

        if (collision.gameObject.CompareTag("Stopper") && transform.localPosition.x > 0.339)
        {
            GetComponent<DrawerMove>().enabled = false;

            Vector3 pos = transform.localPosition;
            pos.x = 0.339f;
            transform.localPosition = pos;

            GetComponent<DrawerMove>().enabled = true;
        }
    }
}