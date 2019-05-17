using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MSRoomPlaneHide : MonoBehaviour {

	// Use this for initialization

	[SerializeField] GameObject Ghost1;
	[SerializeField] GameObject Ghost2;
	[SerializeField]GameObject ChargePlane;
	void Start () {
		
			ChargePlane.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(Ghost1.GetComponent<Escape>().dieatall&&Ghost2.GetComponent<Escape>().dieatall){
			ChargePlane.SetActive(true);
		}
	}
}
