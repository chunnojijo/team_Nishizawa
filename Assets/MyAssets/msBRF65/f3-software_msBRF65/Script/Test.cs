﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour {
    GameObject UIDirector,Text1;
    TextController sc_Text1;
    int i;
    public string[] text;
	// Use this for initialization
	void Start () {
        i = 0;
        Text1 = GameObject.Find("Text");
        sc_Text1 = Text1.GetComponent<TextController>();
        print(sc_Text1);
    }
	
	// Update is called once per frame
	void Update () {
        sc_Text1.Scale(new Vector3(1, 1, 1));
        if (Input.GetMouseButtonDown(0))
        {
            sc_Text1.UI_Update();
        }
    }
}
