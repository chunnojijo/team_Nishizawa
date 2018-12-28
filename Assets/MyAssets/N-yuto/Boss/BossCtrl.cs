using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCtrl : MonoBehaviour {

    float time = 20;
    [SerializeField] GameObject BossMesh;
    [SerializeField] GameObject Kobake;
    [SerializeField] GameObject Cabinett;
    [SerializeField] GameObject Player;
    [SerializeField] BossPathCtrl pathCtrl;
    Animation anim_boss;
    Animation anim_kobake;
    Animator anim_cabinett;
    AudioSource audio_boss;

    IEnumerator coroutine;

    // Use this for initialization
    void Start () {
        if (!Player)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
        }

        coroutine = BossEnumerator();

        anim_boss = BossMesh.GetComponent<Animation>();
        audio_boss = BossMesh.GetComponent<AudioSource>();
        anim_kobake = Kobake.GetComponent<Animation>();
        anim_cabinett = Cabinett.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown("m"))
        {
            StartCoroutine(coroutine);
            Invoke("GoPath",6f);

        }
    }


    private IEnumerator BossEnumerator()
    {
        anim_cabinett.Play("CabinettOpen");
        anim_kobake.Play("kobakeBehaviour");

        yield return new WaitForSeconds(1.3f);

        anim_boss.Play("appear_noRot");
        audio_boss.Play();

        yield return new WaitForSeconds(1.5f);


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


        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("BossPath1"),
                      "time", time, "easeType", iTween.EaseType.linear, "orienttopath", true));

        // DarknessCtrl.ChangeState(DarknessCtrl.State.ChangeToDark, 0.5f);
        // yield return new WaitForSeconds(1);
        // player.transform.position = RespawnPoint.transform.position;
        yield return new WaitForSeconds(1);
       // DarknessCtrl.ChangeState(DarknessCtrl.State.ChangeToClear);

    }

    void GoPath()
    {
        pathCtrl.Go();
    }

    public void CabStart()
    {

        StartCoroutine(coroutine);
        Invoke("GoPath", 6f);
    }

}
