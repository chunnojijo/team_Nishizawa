using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBeamCtrl : MonoBehaviour {

    [SerializeField] private GameObject[] SpotLights;

    public static int ColorMode = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("p"))   //ここ変更すればOK
        {
            ChangeColorMode();
        }
		
	}

    public void ChangeColorMode()
    {
        EyeBeamCtrl.ColorMode = (EyeBeamCtrl.ColorMode + 1) % 4;

        for (int i = 0; i < SpotLights.Length; i++)
        {
            ChangeLightColor(SpotLights[i]);
        }

    }

    public void ChangeColorMode(int mode)
    {
        EyeBeamCtrl.ColorMode = mode;

        for (int i = 0; i < SpotLights.Length; i++)
        {
            ChangeLightColor(SpotLights[i]);
        }

    }

    void ChangeLightColor(GameObject light)
    {
        Color c;

        switch (EyeBeamCtrl.ColorMode)
        {
            case 1: c = new Color(1,0.2f,0.2f,1); break;
            case 2: c = Color.cyan; break;
            case 3: c = Color.yellow; break;
            default: c = Color.white; break;
        }

        light.GetComponent<Light>().color = c;

    }



}
