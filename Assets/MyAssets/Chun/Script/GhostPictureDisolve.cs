using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPictureDisolve : MonoBehaviour {

    private float time = 0;
    private bool disolve = false;
    private Renderer _renderer;

    // Use this for initialization
    void Start () {
        _renderer = GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (time > 2)
        {
            disolve = true;
        }

        if (disolve)
        {
            _renderer.material.EnableKeyword("_Threshold");
        }
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Torch")
        {
            time += Time.deltaTime;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Torch")
        {
            time = 0;
        }
    }
}
