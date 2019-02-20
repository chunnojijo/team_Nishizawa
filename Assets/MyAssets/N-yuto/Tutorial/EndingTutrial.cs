using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingTutrial : MonoBehaviour {

    [SerializeField] string[] ED01_Serif;
    [SerializeField] string[] ED02_Serif;
    [SerializeField] Navi navi;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public IEnumerator ED01()
    {
        navi.Comeback();

        yield return new WaitForSeconds(0.5f);

        navi.Say(ED01_Serif[0]);

        yield return new WaitForSeconds(2f);

        navi.Say(ED01_Serif[1]);

        yield return new WaitForSeconds(2f);

        navi.Say(ED01_Serif[2]);

        yield return new WaitForSeconds(2f);

        Debug.Log("操作方法：");
    }

    public IEnumerator ED02()
    {
        navi.Comeback();

        yield return new WaitForSeconds(0.5f);

        navi.Say(ED02_Serif[0]);

        yield return new WaitForSeconds(2f);

        navi.Say(ED02_Serif[1]);
        //navi.keyDrED();

        yield return new WaitForSeconds(2f);

        navi.Say(ED02_Serif[2]);

        yield return new WaitForSeconds(2f);

        Debug.Log("操作方法：");
    }


}
