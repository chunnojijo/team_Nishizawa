﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningTutrial : MonoBehaviour {

    [SerializeField] Navi navi;

    [SerializeField] GameObject Sun;

    [SerializeField] string[] OP01_Serif;
    [SerializeField] string[] OP02_Serif;
    [SerializeField] string[] OP03_Serif;
    [SerializeField] string[] OP04_Serif;

    [SerializeField] GameObject[] OP02_Position;
    [SerializeField] GameObject[] OP03_Position;
    [SerializeField] GameObject[] OP04_Position;


    [SerializeField] GameObject FlashLight;
    [SerializeField] GameObject ObakeBook;
    [SerializeField] GameObject LightForDebugForAnimation;

    [SerializeField] AudioSource DoorCloseSource;
    [SerializeField] AudioSource DoorLockSource;


    bool OP02_Can_Start = false;
    [SerializeField] GameObject KeyDropPos;

    [HideInInspector] public bool OP04_CanContinue = false;

    // Use this for initialization
    void Start () {
        //DoorLockSource.clip = DoorLock;
        //DoorCloseSource.clip = DoorClose;
	}
	
	// Update is called once per frame
	void Update () {

        //if (Input.GetKeyDown("m")) { StartCoroutine(OP01()); }
		
	}

    private void OnTriggerEnter(Collider other)
    {

    }


    public IEnumerator OP01()
    {
        FlashLight.SetActive(false);

        navi.Comeback();
        navi.LookMe();

        yield return new WaitForSeconds(0.5f);

        navi.Say(OP01_Serif[0]);

        yield return new WaitForSeconds(2f);

        navi.Say(OP01_Serif[1]);

        yield return new WaitForSeconds(2f);

        navi.Say(OP01_Serif[2]);

        yield return new WaitForSeconds(2f);

        navi.DontLookAt();
        Debug.Log("操作方法：");

        while (!OP02_Can_Start)
        {
            yield return null;
        }

        StartCoroutine(OP02());

        yield break;

    }

    public IEnumerator OP02()
    {
        navi.GoTo(OP02_Position[0]);

        yield return new WaitForSeconds(0.5f);

        navi.Say(OP02_Serif[0]);

        yield return new WaitForSeconds(2f);

        navi.Say(OP02_Serif[1]);

        yield return new WaitForSeconds(1f);

        navi.GoTo(OP02_Position[1]);

        yield return new WaitForSeconds(1f);

        navi.LookAt(KeyDropPos);

        yield return new WaitForSeconds(2f);

        navi.Say(OP02_Serif[2]);

        yield return new WaitForSeconds(1f);

        navi.DropKey();

        yield return new WaitForSeconds(1f);

        navi.Say(OP02_Serif[3],true);
        navi.DontLookAt();

        yield return new WaitForSeconds(0.5f);


        Debug.Log("操作方法：");

        yield break;

    }

    public void OP02_GetReady()
    {
        OP02_Can_Start = true;
    }

    public IEnumerator OP03()
    {
        
        Sun.GetComponent<Animator>().SetTrigger("NoEffection");
        yield return new WaitForSeconds(0.1f);

        //DoorCloseSource.Play();
        navi.ComebackSilently();

        //DoorCloseSource.Play();
        yield return new WaitForSeconds(1f);
        
        DoorLockSource.Play();

        yield return new WaitForSeconds(1f);

        navi.Say("ガチャ？");

        yield return new WaitForSeconds(2f);

        navi.Say("ってもしかして");

        yield return new WaitForSeconds(2f);

        navi.Say("閉じ込められちゃった！",true);

        yield return new WaitForSeconds(0.5f);

        LightForDebugForAnimation.GetComponent<Animator>().SetTrigger("LightEvent");

        yield return new WaitForSeconds(4.5f);

        navi.Say("うわっ！真っ暗っ！",true);

        yield return new WaitForSeconds(2f);

        navi.Say(OP03_Serif[1]);

        yield return new WaitForSeconds(2f);

        navi.GoTo(OP03_Position[0]);

        yield return new WaitForSeconds(1f);

        FlashLight.SetActive(true);

        yield return new WaitForSeconds(1f);

        navi.Comeback();
        navi.Say("これで大丈夫！");

        yield return new WaitForSeconds(3f);

        navi.Say(OP03_Serif[3],true);
        navi.GoTo(OP03_Position[1]);

        yield break;

    }

    public void OP03_Invoke()
    {
        StartCoroutine(OP03());
    }
    public void OP04_Invoke()
    {
        StartCoroutine(OP04());
    }

    public IEnumerator OP04()
    {
        navi.GoTo(OP04_Position[0]);

        yield return new WaitForSeconds(0.5f);

        navi.Say(OP04_Serif[0]);//なんだろ
        navi.LookAt(ObakeBook);

        yield return null;

        while (!OP04_CanContinue)
        {
            yield return null;
        }

        navi.Say(OP04_Serif[1]);

        yield return new WaitForSeconds(1f);

        navi.GoTo(OP04_Position[1],true);//HideBackOfPlayer

        yield break;
    }



}
