using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossInstantiater : MonoBehaviour {

    [SerializeField] GameObject CabinettPrefab; 


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("n"))
        {
            ResetBoss();
        }


	}

    public void ResetBoss()
    {
        Instantiate(CabinettPrefab);
    }
}
