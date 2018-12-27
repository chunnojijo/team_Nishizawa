using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCtrl : MonoBehaviour {

    float time = 30;
    [SerializeField] GameObject BossMesh;
    [SerializeField] GameObject Cabinett;
    Animation anim_boss;
    Animator anim_cabinett;

    IEnumerator coroutine;

    // Use this for initialization
    void Start () {

        coroutine = BossEnumerator();

        anim_boss = BossMesh.GetComponent<Animation>();
        anim_cabinett = Cabinett.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown("m"))
        {
            StartCoroutine(coroutine);

        }
    }


    private IEnumerator BossEnumerator()
    {
        anim_cabinett.Play("CabinettOpen");

        yield return new WaitForSeconds(1.3f);

        anim_boss.Play("appear_noRot");

        yield return new WaitForSeconds(1.5f);

        float t = 0;

        while(true)
        {
            BossMesh.transform.localRotation = Quaternion.Euler(-90,0,Mathf.Sin(t * Mathf.PI) * 40);
            t += 0.3f * Time.deltaTime;
            yield return null;
        }

        yield break;

        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("BossPath1"),
                      "time", time, "easeType", iTween.EaseType.linear, "orienttopath", true));

        // DarknessCtrl.ChangeState(DarknessCtrl.State.ChangeToDark, 0.5f);
        // yield return new WaitForSeconds(1);
        // player.transform.position = RespawnPoint.transform.position;
        yield return new WaitForSeconds(1);
       // DarknessCtrl.ChangeState(DarknessCtrl.State.ChangeToClear);

    }

}
