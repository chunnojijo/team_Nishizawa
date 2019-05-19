using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AuraAPI;

public class EndingTutrial : MonoBehaviour {

    [SerializeField] string[] ED01_Serif;
    [SerializeField] GameObject[] ED01_Position;
    [SerializeField] string[] ED02_Serif;

    [SerializeField] Navi navi;

    [SerializeField] GameObject Lastpos;

    bool ED02_Can_Start = false;

    public bool SunRising = false;
    [SerializeField] Light Sun;

    float Duration = 0f;
    [SerializeField] Material skyMat;

    [SerializeField] Camera camera;

    // Use this for initialization
    void Start () {
        skyMat.SetFloat("_Blend", 0f);

    }

    // Update is called once per frame
    void Update () {

        if (SunRising)
        {
            Duration += Time.deltaTime / 40f;
            if (Duration >= 1f)
            {
                Duration = 1f;
                SunRising = false; Debug.Log("FinishSunRise");
            }

            //Sun.intensity = Duration * 8f;
            Sun.gameObject.GetComponent<Animator>().SetTrigger("SunRise");
            
            skyMat.SetFloat("_Blend", Duration);
        }
	}


    public IEnumerator ED01()
    {
        Sun.GetComponent<Animator>().SetTrigger("FirstCondition");
        navi.Comeback();

        yield return new WaitForSeconds(1f);

        navi.Say(ED01_Serif[0]);

        yield return new WaitForSeconds(2f);

        navi.Say(ED01_Serif[1]);

        yield return new WaitForSeconds(2f);

        navi.Say(ED01_Serif[3]);

        yield return new WaitForSeconds(2f);

        navi.GoTo(ED01_Position[0]);

        yield return new WaitForSeconds(2f);

        navi.Say(ED01_Serif[4],true);

        while (!ED02_Can_Start)
        {
            yield return null;
        }

        StartCoroutine(ED02());

        yield break;
    }

    public IEnumerator ED02()
    {
        navi.Say(ED02_Serif[0]);

        yield return new WaitForSeconds(4f);

        yield return new WaitForSeconds(2f);

        navi.Comeback();
        navi.LookMe();

        yield return new WaitForSeconds(2f);

        navi.Say(ED02_Serif[1]);
        this.GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(3f);

        SunRising = true;

        yield return new WaitForSeconds(5f);

        navi.LookAt(Sun.gameObject);
        navi.Say(ED02_Serif[2]);
        navi.GoTo(Lastpos.transform.position);

        yield return new WaitForSeconds(20f);

        navi.LookMe();
        navi.Say(ED02_Serif[3]);

        yield return new WaitForSeconds(3f);
        navi.Comeback();
        navi.Say(ED02_Serif[4]);

        yield return new WaitForSeconds(3f);

        navi.Say(ED02_Serif[5]);

        yield return new WaitForSeconds(3f);

        navi.Say(ED02_Serif[6]);

        yield return new WaitForSeconds(3f);

        DarknessCtrl.ChangeState(DarknessCtrl.State.ChangeToDark);

        yield break;
    }


    public void ED02_GetReady()
    {
        ED02_Can_Start = true;
    }
    
}
