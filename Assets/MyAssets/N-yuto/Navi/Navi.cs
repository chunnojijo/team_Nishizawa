using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navi : MonoBehaviour {

    public GameObject[] PerchObjects; //Perch:止まり木

    [SerializeField] NaviVoice VoiceScript;
    [SerializeField] NaviSerif SerifScript;

    float MoveTime = 2f;
    float SerifTime = 5f;

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


        if (Input.GetKeyDown("p"))
        {
            Say(0);
        }
        if (Input.GetKeyDown("o"))
        {
            Say("Good job!!");
        }
        if (Input.GetKeyDown("i"))
        {
            Say( "Random No. Is ... " + Random.value.ToString(),true);
        }


    }

    public void GoTo(GameObject Target)
    {
        iTween.MoveTo(this.gameObject, Target.transform.position, MoveTime);
        VoiceScript.Play(0);
    }
    public void GoTo(Vector3 WorldPosition)
    {
        iTween.MoveTo(this.gameObject, WorldPosition, MoveTime);
        VoiceScript.Play(0);
    }

    public void Say(string serif, bool permanent = false)
    {
        if (permanent)
        {
            SerifScript.ChangeSerifText(serif);
            VoiceScript.Play(1);
        }
        else
        {
            SerifScript.ChangeSerifText(serif, SerifTime);
            VoiceScript.Play(1);
        }

    }
    public void Say(int serifIndex, bool permanent = false)
    {
        if (permanent)
        {
            SerifScript.ChangeSerifText(serifIndex);
            VoiceScript.Play(1);
        }
        else
        {
            SerifScript.ChangeSerifText(serifIndex, SerifTime);
            VoiceScript.Play(1);
        }

    }


}
