using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vanishing : MonoBehaviour {

    private MeshRenderer renderer;
    [SerializeField] private GameObject GhostsParticles;

    private bool IsVanishing = false;
    [Range(0f,1f)] private float Rate = 1;
    [SerializeField] float TimeToFadeOut = 1f;

    private Vector3 DefScale;


	// Use this for initialization
	void Start () {
        renderer = gameObject.GetComponent<MeshRenderer>();
        DefScale = gameObject.transform.localScale;
        	
	}
	
	// Update is called once per frame
	void Update () {

        if (IsVanishing)
        {
            //renderer.material.color = new Color(1, 1, 1, alpha);
            Rate -= Time.deltaTime / TimeToFadeOut;

            if (Rate <= 0)
            {
                Rate = 0f;
                renderer.enabled = false;
                IsVanishing = false;
            }

            gameObject.transform.localScale = Rate * DefScale;

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
