using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandShaderChange : MonoBehaviour {
    private GameObject righthand,lefthand;

	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (lefthand == null) lefthand = GameObject.Find("hand_left_renderPart_0");
        else lefthand.GetComponent<Renderer>().material.shader = Shader.Find("Unlit/Color");
        if(righthand==null)righthand=GameObject.Find("hand_right_renderPart_0");
        else righthand.GetComponent<Renderer>().material.shader = Shader.Find("Unlit/Color");


    }
}
