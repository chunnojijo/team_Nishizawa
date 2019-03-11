using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ms_roomManegar : MonoBehaviour {
    private bool obake1die = false, obake2die = false,finish =false;
    public GameObject obake1, obake2,donuts,cookies,ms_light;

	// Use this for initialization
	void Start () {
        donuts.SetActive(false);
        cookies.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (!finish)
        {
            if (!obake1die && obake1.gameObject.activeSelf == false)
            {
                obake1die = true;
                donuts.SetActive(true);
            }
            if (!obake2die && obake2.gameObject.activeSelf == false)
            {
                obake2die = true;
                cookies.SetActive(true);
            }
            if (obake1die && obake2die)
            {
                ms_light.GetComponent<ms_LightController>().UnLock();
                finish = true;
            }
        }
    }
}
