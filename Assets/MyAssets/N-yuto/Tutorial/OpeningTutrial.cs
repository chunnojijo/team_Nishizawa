using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningTutrial : MonoBehaviour {

    [SerializeField] Navi navi;

    [SerializeField] string[] OP01_Serif;
    [SerializeField] string[] OP02_Serif;
    [SerializeField] string[] OP03_Serif;

    [SerializeField] GameObject[] OP02_Position;
    [SerializeField] GameObject[] OP03_Position;

    [SerializeField] GameObject FlashLight;

    bool OP02_Can_Start = false;
    [SerializeField] GameObject KeyDropPos;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //if (Input.GetKeyDown("m")) { StartCoroutine(OP01()); }
		
	}

    private void OnTriggerEnter(Collider other)
    {

    }


    public IEnumerator OP01()
    {
        FlashLight.SetActive(false);

        navi.Comeback();
        navi.LookMe();

        yield return new WaitForSeconds(0.5f);

        navi.Say(OP01_Serif[0]);

        yield return new WaitForSeconds(2f);

        navi.Say(OP01_Serif[1]);

        yield return new WaitForSeconds(2f);

        navi.Say(OP01_Serif[2]);

        yield return new WaitForSeconds(2f);

        navi.DontLookAt();
        Debug.Log("操作方法：");

        while (!OP02_Can_Start)
        {
            yield return null;
        }

        StartCoroutine(OP02());

        yield break;

    }

    public IEnumerator OP02()
    {
        navi.GoTo(OP02_Position[0]);

        yield return new WaitForSeconds(0.5f);

        navi.Say(OP02_Serif[0]);

        yield return new WaitForSeconds(2f);

        navi.Say(OP02_Serif[1]);

        yield return new WaitForSeconds(1f);

        navi.GoTo(OP02_Position[1]);

        yield return new WaitForSeconds(1f);

        navi.LookAt(KeyDropPos);

        yield return new WaitForSeconds(2f);

        navi.Say(OP02_Serif[2]);

        yield return new WaitForSeconds(1f);

        navi.DropKey();

        yield return new WaitForSeconds(1f);

        navi.Say(OP02_Serif[3],true);
        navi.DontLookAt();

        yield return new WaitForSeconds(0.5f);

        Debug.Log("操作方法：");

        yield break;

    }

    public void OP02_GetReady()
    {
        OP02_Can_Start = true;
    }

    public IEnumerator OP03()
    {
        yield return new WaitForSeconds(3f);

        navi.Comeback();

        yield return new WaitForSeconds(0.5f);

        navi.Say(OP03_Serif[0]);

        yield return new WaitForSeconds(2f);

        navi.Say(OP03_Serif[1]);

        yield return new WaitForSeconds(1f);

        navi.GoTo(OP03_Position[0]);

        yield return new WaitForSeconds(1f);

        FlashLight.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        navi.Say(OP03_Serif[2]);

        yield return new WaitForSeconds(2f);

        navi.Say(OP03_Serif[3],true);
        navi.ComebackSilently();

        yield break;

    }

    public void OP03_Invoke()
    {
        StartCoroutine(OP03());
    }

}
