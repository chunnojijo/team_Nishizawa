using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningTutrial : MonoBehaviour {

    [SerializeField] string[] OP01_Serif;
    [SerializeField] string[] OP02_Serif;
    [SerializeField] Navi navi;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("m")) { StartCoroutine(OP01(navi)); }
		
	}


    public IEnumerator OP01(Navi navi)
    {
        navi.Comeback();

        yield return new WaitForSeconds(0.5f);

        navi.Say(OP01_Serif[0]);

        yield return new WaitForSeconds(2f);

        navi.Say(OP01_Serif[1]);

        yield return new WaitForSeconds(2f);

        navi.Say(OP01_Serif[2]);

        yield return new WaitForSeconds(2f);

        Debug.Log("操作方法：");
    }

    public IEnumerator OP02(Navi navi)
    {
        navi.Comeback();

        yield return new WaitForSeconds(0.5f);

        navi.Say(OP02_Serif[0]);

        yield return new WaitForSeconds(2f);

        navi.Say(OP02_Serif[1]);
        //navi.keyDrop();

        yield return new WaitForSeconds(2f);

        navi.Say(OP02_Serif[2]);

        yield return new WaitForSeconds(2f);

        Debug.Log("操作方法：");
    }


}
