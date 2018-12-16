using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageController : MonoBehaviour {
    int i;
    public float speed=0.06f;//ズームの速さ(*deltaTimeで最終的に1になるように)
    public int marge=3,first=8;//戻る(余分に広がる)大きさ、初期の大きさ決定
	// Use this for initialization
	void Start () {
        transform.SetAsFirstSibling();
        this.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    public IEnumerator Action()
    {
        first = 8;
        marge=3;
        speed=0.06f;
        Vector3 speed_vec = new Vector3(speed, speed, 0);
        this.gameObject.GetComponent<RectTransform>().localScale = first*speed_vec;
        for (int i = first; i <=1/speed+marge;i++)//初期から余分な大きさまでforで
        {
            this.gameObject.GetComponent<RectTransform>().localScale+=speed_vec;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        for (int i = marge; i >= 0; i--)//大きくし過ぎた分を戻す
        {
            this.gameObject.GetComponent<RectTransform>().localScale -=speed_vec;
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
