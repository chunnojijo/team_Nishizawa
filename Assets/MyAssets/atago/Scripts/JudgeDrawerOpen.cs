using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeDrawerOpen : MonoBehaviour {

    public bool drawerState = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Standard"))
        {
            drawerState = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Standard"))
        {
            drawerState = false;
        }
    }
}
