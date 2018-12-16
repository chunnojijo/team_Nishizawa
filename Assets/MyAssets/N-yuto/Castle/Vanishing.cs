using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vanishing : MonoBehaviour {

    private MeshRenderer renderer;
    [SerializeField] private GameObject GhostsParticles;

    private bool IsVanishing = false;
    [Range(0f,1f)] private float alpha = 1;

	// Use this for initialization
	void Start () {
        renderer = gameObject.GetComponent<MeshRenderer>();
        	
	}
	
	// Update is called once per frame
	void Update () {

        if (IsVanishing)
        {
            renderer.material.color = new Color(1, 1, 1, alpha);
            alpha -= Time.deltaTime;

            if(alpha == 0)
            {
                IsVanishing = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vanish();
        }
		
	}

    void Vanish()
    {
        IsVanishing = true;
        //renderer.enabled = false;
        GhostsParticles.SetActive(true);

    }

}
