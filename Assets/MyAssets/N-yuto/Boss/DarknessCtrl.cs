using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarknessCtrl : MonoBehaviour
{	

    static Texture2D screenTexture;
    [Range(0f, 1f)] static float alpha = 0f;
    [Range(0f, 1f)] static float deltaAlpha = 0.1f;


    public enum State { ChangeToDark,ChangeToClear,Stay }
    static State state = State.Stay;

    public void Awake()
    {
        // 1pixel のTexture2D.
        screenTexture = new Texture2D(1, 1, TextureFormat.ARGB32, false);
        // 色初期化.
        screenTexture.SetPixel(0, 0, new Color(0, 0, 0, alpha));
        // これをしないと色が適用されない.
        screenTexture.Apply();
    }

    public void OnGUI()
    {
        // カメラのサイズで画面全体に描画.
        GUI.DrawTexture(Camera.main.pixelRect, screenTexture);
    }

    
	
	// Update is called once per frame
	void Update () {

        if (state == State.ChangeToDark)
        {
            if (alpha < 1f) { alpha += deltaAlpha * Time.deltaTime; }
            else {
                state = State.Stay;
                alpha = 1f;
            }
            screenTexture.SetPixel(0, 0, new Color(0, 0, 0, alpha));
            screenTexture.Apply();

        }
        if (state == State.ChangeToClear)
        {
            if (alpha > 0f) { alpha -= deltaAlpha * Time.deltaTime; }
            else {
                state = State.Stay;
                alpha = 0f;
            }
            screenTexture.SetPixel(0, 0, new Color(0, 0, 0, alpha));
            screenTexture.Apply();

        }

    }

    public static void ChangeState(State s)
    {
        state = s;
    }
    public static void ChangeState(State s,float time)
    {
        deltaAlpha = 1 / time;
        state = s;
    }


}
