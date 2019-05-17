using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTorch : MonoBehaviour {

    public GameObject torchsource;
    public GameObject torch;
    private float time = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (time > 1)
        {
            torch.GetComponent<Torchelight>().IntensityLight = 0.2f;
        }
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Torch"&&torchsource.GetComponent<Torchelight>().IntensityLight>0)
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
