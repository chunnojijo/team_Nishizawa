using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaviManager : MonoBehaviour {

    [SerializeField]
    private GameObject naviobj;
    [SerializeField]
    private GameObject paper;
    [SerializeField]
    private GameObject Button;
    [SerializeField]
    private GameObject picture;
    private Navi navi;
    private bool first = true;
    private bool firstintro=false;
    private bool button = false;
    private bool buttonfirst = true;
    private bool pictureburnfinish=false;
    private float time = 0;
    //private IEnumerator firstintroie;
	// Use this for initialization
	void Start () {
        navi = naviobj.GetComponent<Navi>();
        
    }
	
	// Update is called once per frame
	void Update () {
        button = Button.GetComponent<SwitchPush>().doorOpen;
        if (firstintro)
        {
            time += Time.deltaTime;
        }
        if (firstintro && time > 20&&!button)
        {
            firstintro = false;
            time = 0;
            StartCoroutine(ButtonHint());
        }

        if (button)
        {
            if (buttonfirst)
            {
                buttonfirst = false;
                time = 0;
            }
            firstintro = false;
            time += Time.deltaTime;
        }
        if (button && time > 20&&!pictureburnfinish)
        {
            button = false;
            time = 0;
            StartCoroutine(PictureHint());
        }

	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (first)
            {
                Debug.Log("success");
                StartCoroutine("FirstIntro");
                first = false;
            }
        }
    }

    IEnumerator FirstIntro()
    {
        navi.Comeback();
        yield return new WaitForSeconds(0.5f);
        navi.Say("あの紙に何か書いてあるね");
       yield return new WaitForSeconds(3.0f);
        navi.GoTo(paper.transform.position+new Vector3(-1.5f,0,0));
        yield return new WaitForSeconds(2.0f);
        navi.Say("やっほー",true);
        yield return null;
        firstintro = true;
        yield return null;
    }

    IEnumerator ButtonHint()
    {
        
         navi.GoTo(Button.transform.position + new Vector3(-1, 0, -1.5f));
         yield return new WaitForSeconds(2.5f);
         navi.Say("こんなところに変なボタンがあるね..", true);
         yield return null;
    }

    IEnumerator PictureHint()
    {
        navi.GoTo(picture.transform.position+new Vector3(2,0,1));
        yield return new WaitForSeconds(2);
        navi.Say("あぶりだす..絵画..もしかして..?", true);
        pictureburnfinish = true;
        yield return null;
    }
}
