using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navi : MonoBehaviour {

    public GameObject[] PerchObjects; //Perch:止まり木

    [SerializeField] NaviVoice VoiceScript;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("0"))
        {
            if (PerchObjects.Length > 0) GoTo(PerchObjects[0]);
        }
        if (Input.GetKeyDown("1"))
        {
            if (PerchObjects.Length > 1) GoTo(PerchObjects[1]);
        }
        if (Input.GetKeyDown("2"))
        {
            if (PerchObjects.Length > 2) GoTo(PerchObjects[2]);
        }
        if (Input.GetKeyDown("3"))
        {
            if (PerchObjects.Length > 3) GoTo(PerchObjects[3]);
        }


    }

    public void GoTo(GameObject Target)
    {
        iTween.MoveTo(this.gameObject, Target.transform.position, 2f);
        VoiceScript.Play(0);
    }
    public void GoTo(Vector3 WorldPosition)
    {
        iTween.MoveTo(this.gameObject, WorldPosition, 2f);
        VoiceScript.Play(0);
    }



}
