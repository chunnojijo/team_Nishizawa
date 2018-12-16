using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {
    // Use this for initialization
    public string[] text;
    public GameObject image;
    int i = -1;
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UI_Update()
    {
        i++;
        if (i < text.Length)
        {
            this.GetComponent<Text>().text="";
            image.gameObject.SetActive(true);
            ImageController Image = image.GetComponent<ImageController>();
            StartCoroutine(Image.Action());
            Invoke("WriteUI",(1/Image.speed+Image.marge*2)*Time.deltaTime+0.3f);//関数の発生を遅らせる
        }
    }

    //textboxの大きさを調整(vector3でコピー元との相対的な大きさを操作)
    public void Scale(Vector3 scale)
    {
        this.gameObject.GetComponent<Text>().rectTransform.localScale = scale;
    }

    //UIへの書き込み
    void WriteUI()
    {
        this.GetComponent<Text>().text = text[i];

    }
}
