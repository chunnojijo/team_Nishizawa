using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Escape : MonoBehaviour {
    public float Rotatospeed=5;
    public float Scalespeed = 0.02f;
    public float floatwidth = 2.0f;
    public float floatspeed = 2.0f;
    public bool damage = false;
    public bool appear = false;



    private bool escape = false;
    private bool apfirst = true;
    private bool damagefirst = false;
    private bool moveslide=true;
    private AudioSource[] audiosource;
    private Color color;
    private ParticleSystem[] particlesystem;
    private float x, y;
    private float time = 0;
    private const float maxEnemyHP = 3;
    private float enemyHP = maxEnemyHP;
    private GameObject[] particles;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private ParticleSystem smokeparticle;
    [SerializeField]
    private ParticleSystem starparticle;
    [SerializeField]
    private ParticleSystem damageparticle;
    [SerializeField]
    private Slider slider;
    
    void Start () {
        audiosource = this.GetComponents<AudioSource>();
        particlesystem = this.GetComponentsInChildren<ParticleSystem>();
        GetComponent<MeshRenderer>().enabled = false;
        slider.maxValue = maxEnemyHP;
        slider.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        //For Debug
        if (Input.GetKey(KeyCode.RightArrow)) transform.position += new Vector3(0.5f, 0, 0);
        if (Input.GetKey(KeyCode.LeftArrow)) transform.position += new Vector3(-0.5f, 0, 0);
        if (Input.GetKeyDown(KeyCode.E)) escape = true;
        if (Input.GetKeyDown(KeyCode.A)) appear = true;
        if (Input.GetKeyDown(KeyCode.D) && !damage) damage = true;
        else if (Input.GetKeyDown(KeyCode.D)) damage = false;
        //For Debug


        moveFloat();

        //HPバーの処理
        slider.value = enemyHP;
        //slider.transform.LookAt(player.transform.position);
        //HPバーの処理



        Defeat();
       
	}

    /// <summary>
    /// 上下にふわふわ浮く処理　moveslide=falseで止められる
    /// </summary>
    void moveFloat()
    {
        time += Time.deltaTime;
        if (moveslide) transform.position += new Vector3(0, floatwidth * (Mathf.Sin(time * floatspeed) - Mathf.Sin((time - Time.deltaTime) * floatspeed)), 0);
    }


    /// <summary>
    /// やられたときの処理 appear=trueで出現、damage=trueでダメージを受ける
    /// </summary>
    void Defeat()
    {
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
            slider.gameObject.SetActive(false);
        }


        if (appear)
        {
            if (apfirst)
            {
                transform.localScale = new Vector3(0, 0, 0);
                smokeparticle.Play();
                audiosource[1].Play();
                apfirst = false;
                GetComponent<MeshRenderer>().enabled = true;
                slider.gameObject.SetActive(true);
            }
            if (transform.localScale.x < 10) transform.localScale += new Vector3(Scalespeed, Scalespeed, Scalespeed);
            if (transform.localScale.x >= 10)
            {
                appear = false;
            }
        }


        if (damage)
        {
            if (!damagefirst)
            {
                damageparticle.gameObject.SetActive(true);
                damageparticle.Play();
                damagefirst = true;
            }
            enemyHP -= Time.deltaTime;
            moveslide = false;
        }
        else
        {
            damageparticle.Stop();
            damageparticle.gameObject.SetActive(false);
            damagefirst = false;
            moveslide = true;
        }

        if (enemyHP <= 0)
        {
            escape = true;
            damage = false;
        }
    }
}


