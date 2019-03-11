using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPictureDisolve : MonoBehaviour {

    public GameObject Torche;
    private float time = 0;
    public bool disolve = false;
    public bool dissolvefinish = false;
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
            time += Time.deltaTime;
            _renderer.material.SetFloat("_Threshold", (time -2)*0.3f);
            if ((time - 2) * 0.3f > 1) dissolvefinish = true;
        }
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Torch"&&Torche.GetComponent<Torchelight>().IntensityLight>0)
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
