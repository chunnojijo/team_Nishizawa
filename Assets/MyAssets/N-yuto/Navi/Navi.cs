using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navi : MonoBehaviour {

    public GameObject Player;
    [SerializeField] GameObject Key;

    [SerializeField] GameObject KeyDropPosition;
    public GameObject playerSidePosition;
    public GameObject[] PerchObjects; //Perch:止まり木

    [SerializeField] NaviVoice VoiceScript;
    [SerializeField] NaviSerif SerifScript;

    float MoveTime = 2f;
    float SerifTime = 5f;

    [HideInInspector] public bool IsFollowingPlayer = false;

    float DropSpeed = 4f;
    
    Coroutine hint;

    Rigidbody KeyRb;

    // Use this for initialization
    void Start () {
        KeyRb = Key.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update () {

        if (IsFollowingPlayer)
        {
            iTween.MoveUpdate(gameObject, playerSidePosition.transform.position, 4f);
        }


     //以降デバッグ用
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

        if (Input.GetKeyDown("u"))
        {
            Comeback();
        }
        if (Input.GetKeyDown("j"))
        {
            DontFollowMe();
        }

        if (Input.GetKeyDown("l"))
        {
            hint = Hint(2f, "ここが怪しいよ！", PerchObjects[1].transform.position);
        }
        if (Input.GetKeyDown("k"))
        {
            StopHint(hint);
        }

        if (Input.GetKeyDown("n"))
        {
            DropKey();
        }

    }

    public void GoTo(GameObject Target)
    {
        iTween.MoveTo(this.gameObject, Target.transform.position, MoveTime);
        VoiceScript.Play(0);
        IsFollowingPlayer = false;
    }
    public void GoTo(Vector3 WorldPosition)
    {
        iTween.MoveTo(this.gameObject, WorldPosition, MoveTime);
        VoiceScript.Play(0);
        IsFollowingPlayer = false;
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

    public void Shutup()
    {
        SerifScript.ClearText();
    }

    public void Comeback()
    {
        IsFollowingPlayer = true; //MoveUpdateが発動
        VoiceScript.Play(0);
    }
    public void ComebackSilently()
    {
        IsFollowingPlayer = true; //MoveUpdateが発動
    }

    public void DontFollowMe()
    {
        IsFollowingPlayer = false;
    }

    public void DropKey()
    {
        Key.SetActive(true);
        KeyRb.position = gameObject.transform.position;
        KeyRb.velocity = ( Vector3.up + KeyDropPosition.transform.position - gameObject.transform.position ) * DropSpeed;
    }

    public Coroutine Hint(float time, string serif, Vector3 position)
    {
        return StartCoroutine(HintCoroutine(time, serif, position));
    } 

    public void StopHint(Coroutine hint,bool shutup = true)
    {
        StopCoroutine(hint);
        Debug.Log("Hintは実行されませんでした");
        if (shutup) Shutup();
    }

    IEnumerator HintCoroutine(float time, string serif, Vector3 position)
    {
        yield return new WaitForSeconds(time);

        Debug.Log("Hint!");
        Say(serif,true);
        yield return new WaitForSeconds(1f);
        GoTo(position);

        
    }
}
