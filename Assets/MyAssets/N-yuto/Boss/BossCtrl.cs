using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCtrl : MonoBehaviour {

    float time = 100;
    Animation anim;

	// Use this for initialization
	void Start () {
        anim = gameObject.GetComponent<Animation>();
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("m"))
        {
            StartCoroutine("BossEnumerator");

        }
    }


    private IEnumerator BossEnumerator()
    {
        //anim.Play("appear");

        yield return new WaitForSeconds(1);

        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("BossPath1"),
                      "time", time, "easeType", iTween.EaseType.linear, "orienttopath", true));

        // DarknessCtrl.ChangeState(DarknessCtrl.State.ChangeToDark, 0.5f);
        // yield return new WaitForSeconds(1);
        // player.transform.position = RespawnPoint.transform.position;
        yield return new WaitForSeconds(1);
       // DarknessCtrl.ChangeState(DarknessCtrl.State.ChangeToClear);

    }

}
