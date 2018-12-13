using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCtrl : MonoBehaviour {

    [SerializeField]GameObject darkness;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            DarknessCtrl.ChangeState(DarknessCtrl.State.ChangeToDark,0.5f);
        }
        
    }

    void Darken()
    {
        MeshRenderer darkRenderer = darkness.GetComponent<MeshRenderer>();

        darkRenderer.material.color = new Color(0f,0f,0f,1f);

    }

}
