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

		Invoke("Change",0.5f);
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
            if (Input.GetKeyDown("r"))
            {
                transform.RotateAround(HMD.transform.position, Vector3.up, -22.5f);
            }

        }
	}

	public void Change(){
        Vector3 localPos = this.transform.InverseTransformPoint(HMD.transform.position);
        //Debug.Log(localPos + "<-local world->" + HMD.transform.position);
		CC.center =new Vector3(localPos.x,CC.center.y,localPos.z);
	}
}
