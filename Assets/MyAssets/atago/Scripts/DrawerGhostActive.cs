using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerGhostActive : MonoBehaviour {

    public GameObject obake;
	void Update () {
        if (GetComponent<JudgeDrawerOpen>().drawerState)
        {
            obake.SetActive(true);
        }
	}
}
