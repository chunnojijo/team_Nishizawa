using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    // Use this for initialization
    public string[] text;
    string all_serif;
    public GameObject image;
    int i = 0;
    public TextAsset serif;
    ImageController Image;

    void Start()
    {
        all_serif = serif.text;
        Debug.Log(all_serif);
        text = all_serif.Split('\n');
        Debug.Log(text);
        Image = image.GetComponent<ImageController>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void UI_Update()
    {
        i++;
        //Debug.Log(text[i]);
        if (i < text.Length-1)
        {
            if (text[i] != text[0])//text[0]はpause、最後は空白
            {
                this.GetComponent<Text>().text = "";
                image.gameObject.SetActive(true);
                StartCoroutine(Image.Action());
                Invoke("WriteUI", (1 / Image.speed + Image.marge * 2) * Time.deltaTime + 0.1f);//関数の発生を遅らせる
            }
            else
            {
                image.gameObject.SetActive(false);
                this.GetComponent<Text>().text = "";
            }
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