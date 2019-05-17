using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ms_roomManegar : MonoBehaviour {
    public bool finish =false;
    public GameObject obake1,obake2,donuts,cookies,ms_light_plane,key,navi,navi_pos,navi_pos1,navi_pos2,ms_light;
    Escape escape1, escape2;
    Navi navi_s;
    bool flag1 = true, flag2 = true, flag3 = true;

	// Use this for initialization
	void Start () {
        navi_s = navi.GetComponent<Navi>();
        
        donuts.SetActive(false);
        cookies.SetActive(false);
        escape1 = obake1.GetComponent<Escape>();
        escape2 = obake2.GetComponent<Escape>();

    }
	
	// Update is called once per frame
	void Update () {

        //Debug.Log(escape1);
        //Debug.Log(escape2.dieatall);
        if (!finish)
        {
            if (navi_pos.GetComponent<start_navi>().collision && flag1)
            {
                StartCoroutine("first_serif");
                flag1 = false;
            }
            if (escape1.dieatall == true)
            {
                donuts.SetActive(true);
            }
            if (escape2.dieatall == true)
            {
                cookies.SetActive(true);
            }
            if (escape1.dieatall && escape2.dieatall && flag2)
            {
                ms_light_plane.gameObject.SetActive(true);
                StartCoroutine("hint");
                flag2 = false;
            }
            if (ms_light.GetComponent<ms_LightController>().finish_color && flag3)
            {
                StartCoroutine("hint_getkey");
                flag3 = false;
                finish = true;
            }
        }
    }

    IEnumerator first_serif()
    {
        yield return new WaitForSeconds(3f);
        navi_s.GoTo(navi_pos.transform.position);
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
        navi_s.GoTo(navi_pos1.transform.position);
        yield return new WaitForSeconds(3f);
        navi_s.Say("鍵を手に入れないと、出れないよ！");
        yield return new WaitForSeconds(3f);
        navi_s.Say("あそこにあるChargeの文字は何だろう？？");
        yield return new WaitForSeconds(3f);
    }
    IEnumerator hint_getkey()
    {
        yield return new WaitForSeconds(3f);
        navi_s.GoTo(navi_pos2.transform.position);
        yield return new WaitForSeconds(3f);
        navi_s.Say("鍵の影が出てきたね！");
        yield return new WaitForSeconds(3f);
        navi_s.Say("近づいてみたら何かあるかも，，？");
        yield return new WaitForSeconds(3f);
    }
}

