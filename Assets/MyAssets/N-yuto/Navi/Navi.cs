using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navi : MonoBehaviour {

    public GameObject Player;

    public GameObject playerSidePosition;
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


        if (Input.GetKeyDown("l"))
        {
            Hint(2f, "", Vector3.back, true);

        }


    }

    public void GoTo(GameObject Target)
    {
        iTween.MoveTo(this.gameObject, Target.transform.position, MoveTime);
        VoiceScript.Play(0);
        gameObject.transform.parent = null;
    }
    public void GoTo(Vector3 WorldPosition)
    {
        iTween.MoveTo(this.gameObject, WorldPosition, MoveTime);
        VoiceScript.Play(0);
        gameObject.transform.parent = null;
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

    /*
    public void Say(string serif, float time)
    {

        SerifScript.ChangeSerifText(serif, time);
        VoiceScript.Play(1);


    }
    public void Say(int serifIndex, float time)
    {
       
            SerifScript.ChangeSerifText(serifIndex, time);
            VoiceScript.Play(1);
       

    }
    */

    public void Comeback()
    {
        gameObject.transform.parent = Player.transform;
        iTween.MoveTo(gameObject, playerSidePosition.transform.position, MoveTime);
        //要修正：

    }


    public void Hint(float time, string serif, Vector3 position, bool done)
    {
        StartCoroutine("HintCoroutine",time);
        //待ってくれない。
        Debug.Log("HintDone");

    } 

    IEnumerator HintCoroutine(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
