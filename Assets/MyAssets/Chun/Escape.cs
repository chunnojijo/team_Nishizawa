using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : MonoBehaviour {
    public float Rotatospeed=5;
    public float Scalespeed = 0.02f;
    public float floatwidth = 2.0f;
    public float floatspeed = 2.0f;
    
    private bool escape = false;
    private bool appear = false;
    private bool apfirst = true;
    private AudioSource[] audiosource;
    private Color color;
    private ParticleSystem[] particlesystem;
    private float x, y;
    private float time = 0;
    private GameObject[] particles;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private ParticleSystem smokeparticle;
    [SerializeField]
    private ParticleSystem starparticle;

    
    void Start () {
        audiosource = this.GetComponents<AudioSource>();
        particlesystem = this.GetComponentsInChildren<ParticleSystem>();
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.E)) escape = true;
        transform.position += new Vector3(0, floatwidth * (Mathf.Sin(time*floatspeed) - Mathf.Sin((time - Time.deltaTime)*floatspeed)),0);
        if (Input.GetKey(KeyCode.RightArrow)) transform.position += new Vector3(0.5f, 0, 0);
        if (Input.GetKey(KeyCode.LeftArrow)) transform.position += new Vector3(-0.5f, 0, 0);

        if(!escape)transform.LookAt(player.transform.position,transform.up.normalized);


        


        if (escape)
        {
            transform.Rotate(0, Rotatospeed, 0);
            transform.localScale -= new Vector3(Scalespeed, Scalespeed, Scalespeed);
            audiosource[0].Play();
            if (transform.localScale.x <= 0)
            {
                starparticle.Play();
                Destroy(this);
            }
        }
        if (Input.GetKeyDown(KeyCode.A)) appear = true;
        if (appear)
        {
            if (apfirst)
            {
                transform.localScale = new Vector3(0, 0, 0);
                smokeparticle.Play();
                audiosource[1].Play();
                apfirst = false;
            }
            if(transform.localScale.x<1)transform.localScale += new Vector3(Scalespeed, Scalespeed, Scalespeed);
            if (transform.localScale.x >= 1)
            {
                appear = false;
            }
        }
	}
}
