using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class AppearGhost : MonoBehaviour {

    float time = 0;
    [SerializeField]
    private GameObject Ghost;
    private bool first=true;
	// Use this for initialization
	void Start () {
        IEnumerator coroutine;
	}
	
	// Update is called once per frame
	void Update () {
        if (this.GetComponent<GhostPictureDisolve>().dissolvefinish)
        {
            time += Time.deltaTime;
        }
        if (time > 0.5f)
        {
            if (first)
            {
                first = false;
                Ghost.GetComponent<Escape>().appear = true;
            }
        }
	}

    
}
