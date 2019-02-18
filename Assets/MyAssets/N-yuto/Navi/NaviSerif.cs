using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NaviSerif : MonoBehaviour {

    [SerializeField] TextMeshProUGUI textMeshPro;
    public List<string> SerifList;

    float FadeSpeed = 3f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeSerifText(int SerifNumber)
    {
        CancelInvoke();
        textMeshPro.text = SerifList[SerifNumber];
        StartCoroutine(FadeIn());
    }
    public void ChangeSerifText(int SerifNumber,float time)
    {
        CancelInvoke();
        textMeshPro.text = SerifList[SerifNumber];
        StartCoroutine(FadeIn());
        Invoke("ClearText", time);
    }
    public void ChangeSerifText(string serif)
    {
        CancelInvoke();
        textMeshPro.text = serif;
        StartCoroutine(FadeIn());
    }
    public void ChangeSerifText(string serif, float time)
    {
        CancelInvoke();
        textMeshPro.text = serif;
        StartCoroutine(FadeIn());
        Invoke("ClearText", time);
    }



    public void ClearText()
    {
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeIn()
    {
        Color color = textMeshPro.color;
        float alpha = 0f;


        while (alpha <= 1f)
        {
            alpha += Time.deltaTime * FadeSpeed;
            textMeshPro.color = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }

        textMeshPro.color = new Color(color.r, color.g, color.b, 1f);

        yield break;
    }

    private IEnumerator FadeOut()
    {
        Color color = textMeshPro.color;
        float alpha = color.a;


        while (alpha >= 0f)
        {
            alpha -= Time.deltaTime * FadeSpeed;
            textMeshPro.color = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }

        ChangeSerifText("");
        textMeshPro.color = new Color(color.r, color.g, color.b, 0f);

        yield break;
    }

}

