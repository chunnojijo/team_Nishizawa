using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ms_roomManegar : MonoBehaviour {
    public bool finish =false;
    public GameObject obake1, obake2,donuts,cookies,ms_light,key;
    Escape escape1, escape2;

	// Use this for initialization
	void Start () {
        donuts.SetActive(false);
        cookies.SetActive(false);
        escape1 = obake1.GetComponent<Escape>();
        escape2 = obake2.GetComponent<Escape>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!finish)
        {
            if (escape1.dieatall == true)
            {
                donuts.SetActive(true);
            }
            if (escape2.dieatall == true)
            {
                cookies.SetActive(true);
            }
            if (escape1.dieatall && escape2.dieatall)
            {
                ms_light.gameObject.SetActive(true);
                finish = true;
            }
        }
    }
}
