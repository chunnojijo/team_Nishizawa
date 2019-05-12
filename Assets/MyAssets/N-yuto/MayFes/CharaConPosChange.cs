using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaConPosChange : MonoBehaviour {

	[SerializeField] GameObject HMD;
	CharacterController CC;
	// Use this for initialization

	[SerializeField] bool IsDebugging;
	void Start () {
		CC = GetComponent<CharacterController>();

		Invoke("Change",5f);
	}
	
	// Update is called once per frame
	void Update () {
		if(IsDebugging)
		{
			if(Input.GetKeyDown("c"))
			{
				Change();
				Debug.LogWarning("CC Moved");
			}

		}
	}

	void Change(){
		CC.center = Quaternion.AngleAxis(transform.eulerAngles.y,Vector3.up) * (new Vector3(-(this.transform.position - HMD.transform.position).x,CC.center.y,-(this.transform.position - HMD.transform.position).z));

	}
}
