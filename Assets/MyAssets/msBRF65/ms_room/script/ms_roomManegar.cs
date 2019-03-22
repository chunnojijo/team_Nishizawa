﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ms_roomManegar : MonoBehaviour {
    public bool finish =false;
    public GameObject obake1,obake2,donuts,cookies,ms_light,key,navi;
    Escape escape1, escape2;
    Navi navi_s;

	// Use this for initialization
	void Start () {
        navi_s = navi.GetComponent<Navi>();
        StartCoroutine("first_serif");
        donuts.SetActive(false);
        cookies.SetActive(false);
        escape1 = obake1.GetComponent<Escape>();
        escape2 = obake2.GetComponent<Escape>();
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(escape1);
        Debug.Log(escape2.dieatall);
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
                StartCoroutine("hint");
                finish = true;
            }
        }
    }

    IEnumerator first_serif()
    {
        yield return new WaitForSeconds(3f);
        navi_s.GoTo(new Vector3(-19.27f,1.26f,-4.64f));
        yield return new WaitForSeconds(3f);
        navi_s.Say("ここでは、お菓子好きのお化けがいるよ");
        yield return new WaitForSeconds(3f);
        navi_s.Say("お化けを倒してね！");
        yield return new WaitForSeconds(3f);
        navi_s.Comeback();
    }
    IEnumerator hint()
    {
        yield return new WaitForSeconds(3f);
        navi_s.Say("鍵を手に入れないと、出れないよ！");
        yield return new WaitForSeconds(3f);
    }
}

