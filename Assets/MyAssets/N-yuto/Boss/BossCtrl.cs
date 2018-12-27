using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCtrl : MonoBehaviour {

    float time = 30;
    [SerializeField] GameObject BossMesh;
    [SerializeField] GameObject Kobake;
    [SerializeField] GameObject Cabinett;
    [SerializeField] GameObject Player;
    Animation anim_boss;
    Animation anim_kobake;
    Animator anim_cabinett;

    IEnumerator coroutine;

    // Use this for initialization
    void Start () {

        coroutine = BossEnumerator();

        anim_boss = BossMesh.GetComponent<Animation>();
        anim_kobake = Kobake.GetComponent<Animation>();
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
        anim_kobake.Play("kobakeBehaviour");

        yield return new WaitForSeconds(1.3f);

        anim_boss.Play("appear_noRot");

        yield return new WaitForSeconds(1.5f);

        float t = 0;

        //while(t<=2)
       // {
        //   transform.localRotation = Quaternion.Euler(-90,0,Mathf.Sin(t * 0.3f * Mathf.PI) * 40);
          //  t += Time.deltaTime;
            //yield return null;
        //}

        while (true)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(Player.transform.position - transform.position), Time.deltaTime * 15);
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
