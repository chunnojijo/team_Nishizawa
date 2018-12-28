using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPathCtrl : MonoBehaviour {

   // public int time = 100;
   // public string PathName = "BossPath";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

       // if (Input.GetKeyDown(KeyCode.Space))
       // {
     //       iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath(PathName),
       //                                 "time", time, "easeType", iTween.EaseType.linear, "orienttopath", true));
      //  }

    }

    public void Go()
    {

        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("BossPath1"),
               "time", 30, "easeType", iTween.EaseType.linear, "orienttopath", false));

    }
}
