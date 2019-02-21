using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OutSideSwich : MonoBehaviour {

    //OutSideのON/OFF、暗転明転、プレイヤーのワープ

    [SerializeField] OpeningTutrial openingEvent;
    [SerializeField] EndingTutrial endingEvent;

    [SerializeField] Transform player;
    [SerializeField] Navi navi;

    [SerializeField] Transform OP_CamPos;
    [SerializeField] Transform Inside_CamPos;
    [SerializeField] Transform ED_CamPos;

    [SerializeField] Transform OP_NaviPos;
    [SerializeField] Transform Inside_NaviPos;
    [SerializeField] Transform ED_NaviPos;

    [SerializeField] Transform[] Debug_CamPos;


    public UnityEvent ON_OpeningMode;
    public UnityEvent ON_EndingMode;
    public UnityEvent OFF;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("o") && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            StartCoroutine(Opening());
        }
        if (Input.GetKeyDown("i") && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            StartCoroutine(GoInside());
        }
        if (Input.GetKeyDown("e") && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            StartCoroutine(Ending());
        }

    }

    public IEnumerator Opening()
    {

        DarknessCtrl.ChangeState(DarknessCtrl.State.ChangeToDark, 0.5f);

        yield return new WaitForSeconds(1f);

        navi.Shutup();
        ON_OpeningMode.Invoke();

        yield return null;

        player.transform.position = OP_CamPos.position;
        player.transform.rotation = OP_CamPos.rotation;

        yield return null;

        navi.transform.position = OP_NaviPos.position;
        navi.transform.rotation = OP_NaviPos.rotation;

        yield return new WaitForSeconds(1f);

        DarknessCtrl.ChangeState(DarknessCtrl.State.ChangeToClear);

        yield return new WaitForSeconds(1f);

        StartCoroutine(openingEvent.OP01());

    }

    public IEnumerator GoInside()
    {
        DarknessCtrl.ChangeState(DarknessCtrl.State.ChangeToDark, 0.5f);

        yield return new WaitForSeconds(1f);

        player.position = Inside_CamPos.position;
        player.rotation = Inside_CamPos.rotation;

        yield return null;

        navi.transform.position = Inside_NaviPos.position;
        navi.transform.rotation = Inside_NaviPos.rotation;

        yield return null;

        navi.Shutup();
        OFF.Invoke();

        yield return new WaitForSeconds(1f);

        DarknessCtrl.ChangeState(DarknessCtrl.State.ChangeToClear);

        yield return new WaitForSeconds(1f);
    }

    public IEnumerator Ending()
    {
        DarknessCtrl.ChangeState(DarknessCtrl.State.ChangeToDark, 0.5f);

        yield return new WaitForSeconds(1f);

        navi.Shutup();
        ON_EndingMode.Invoke();

        yield return null;

        player.position = ED_CamPos.position;
        player.rotation = ED_CamPos.rotation;

        yield return null;

        navi.transform.position = ED_NaviPos.position;
        navi.transform.rotation = ED_NaviPos.rotation;

        yield return new WaitForSeconds(1f);

        DarknessCtrl.ChangeState(DarknessCtrl.State.ChangeToClear);

        yield return new WaitForSeconds(1f);

        StartCoroutine(endingEvent.ED01());
    }

}
