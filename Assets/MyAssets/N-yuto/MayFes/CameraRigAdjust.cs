using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRigAdjust : MonoBehaviour {

	//attach to HMD

	[SerializeField]bool IsDebugging;
	[Space(10)]
	[SerializeField] GameObject Rig;
	[SerializeField] GameObject HeadPosition;
	[SerializeField] GameObject HMD;

	Vector3 HMDtoHeadPos;
	Vector3 adjustVec;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(IsDebugging)
		{
			if(Input.GetKeyDown("a"))
			{
				Adjust();
				Debug.LogWarning("Rig Moved" + -HMDtoHeadPos);
			}

		}
	}

	void Adjust(){

		HMDtoHeadPos = HeadPosition.transform.position - HMD.transform.position;
		Rig.transform.Translate(-HMDtoHeadPos);
	}
}
