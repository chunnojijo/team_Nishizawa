using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetFireTorcheController : MonoBehaviour {

    [SerializeField]private GameObject redButton;

	// Use this for initialization
	void Start () {
        this.GetComponent<Torchelight>().IntensityLight = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (redButton.GetComponent<SwitchPush>().doorOpen)
        {
            this.GetComponent<Torchelight>().IntensityLight = 0.2f;
        }
	}
}
