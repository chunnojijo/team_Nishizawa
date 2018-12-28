﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag_Controller : MonoBehaviour {
    public GameObject Text1;
    TextController sc_Text1;

    // Use this for initialization
    void Start () {
        sc_Text1 = Text1.GetComponent<TextController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider collider)
    {
        StartCoroutine("Start_Serif");
    }

    IEnumerator Start_Serif()
    {
        for (int i = 0; i < sc_Text1.text.Length-1; i++)
        {
            sc_Text1.UI_Update();
            yield return new WaitForSeconds(5.0f);
        }
        GameObject.Destroy(this.gameObject);
    }
}

