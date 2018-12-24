using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Escape : MonoBehaviour {
    public float Rotatodiespeed=5;
    public float Scalespeed = 0.02f;
    public float floatwidth = 2.0f;
    public float floatspeed = 2.0f;
    public bool damage = false;
    public bool appear = false;
    public bool escape = false;
    public float maxEnemyHP = 3;
    public float escapetime = 1;
    public float Rotatemovespeed = 0.5f;
    public float movespeed = 0.1f;
    public float escapedistance = 5.0f;


    private bool die = false;
    private bool escapefirst = true;
    private bool apfirst = true;
    private bool damagefirst = false;
    private bool moveslide=true;
    private bool rotationmove = true;
    private bool move = false;
    private bool aftermovefirst = false;
    private bool aftermove = false;
    private int maxdirection;
    private LayerMask mask;
    private AudioSource[] audiosource;
    private Color color;
    private ParticleSystem[] particlesystem;
    private float x, y;
    private float time = 0;
    private float enemyHP;
    private float watchedtime=0;
    private float[] distancefromobj;
    private float distancefromobjmax=3;
    private float angle;
    private GameObject parent;
    private GameObject[] particles;
    private Ray[] around;
    private RaycastHit hit;
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
        enemyHP = maxEnemyHP;
        distancefromobj = new float[8];
        around = new Ray[8];
        parent = this.transform.root.gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        //For Debug
        if (Input.GetKeyDown(KeyCode.A)) appear = true;
        if (Input.GetKeyDown(KeyCode.E)) escape = true;
        if (Input.GetKeyDown(KeyCode.D) && !damage) damage = true;
        else if (Input.GetKeyDown(KeyCode.D)) damage = false;
        //For Debug
        
       

        if ((player.transform.position - parent.transform.position).magnitude < escapedistance&&!escape)
        {
            //watchedtime += Time.deltaTime;
            //if (watchedtime > escapetime)
            //{
                //watchedtime =0;
                escape = true;
            //}
        }

        //Debug.Log("player-ghost distance=" + (player.transform.root.gameObject.transform.TransformPoint(player.transform.position) - parent.transform.TransformPoint(this.transform.position)).magnitude);
        Escapefromplayer();
        moveFloat();
        

        //HPバーの処理
        slider.value = enemyHP;
        //slider.transform.LookAt(transform.TransformPoint(player.transform.position));
        //HPバーの処理



        Defeat();
       
	}

    /// <summary>
    /// プレイヤーから逃げる処理　escape=trueで逃げる処理が始まる
    /// </summary>
    void Escapefromplayer()
    {
        if (escape&&!damage)
        {
            //escapeに入ったとき最初だけ行う処理
            if (escapefirst)
            {
                around[0] = new Ray(this.transform.position, this.transform.forward * 1000);
                around[1] = new Ray(this.transform.position, (this.transform.forward + this.transform.right) * 1000);
                around[2] = new Ray(this.transform.position, this.transform.right * 1000);
                around[3] = new Ray(this.transform.position, (-this.transform.forward + this.transform.right) * 1000);
                around[4] = new Ray(this.transform.position, -this.transform.forward * 1000);
                around[5] = new Ray(this.transform.position, (-this.transform.forward - this.transform.right) * 1000);
                around[6] = new Ray(this.transform.position, -this.transform.right * 1000);
                around[7] = new Ray(this.transform.position, (this.transform.forward - this.transform.right) * 1000);
                escapefirst = false;
                for (int i = 0; i < 8; i++)
                {
                    if (Physics.Raycast(around[i], out hit))
                    {
                        distancefromobj[i] = hit.distance;
                        if (distancefromobjmax < distancefromobj[i])
                        {
                            if (Vector3.Dot(player.transform.forward.normalized, around[i].direction.normalized) > 0)
                            {
                                distancefromobjmax = distancefromobj[i];
                                maxdirection = i;
                                //Debug.Log("Dot=" + Vector3.Dot(player.transform.forward.normalized, around[i].direction.normalized));
                                //Debug.Log("maxdirection=" + maxdirection);
                            }
                        }
                    }
                }
                //maxdirectionとforwardがなす角度
                angle = Vector3.Angle(this.transform.forward, around[maxdirection].direction) * (Vector3.Cross(this.transform.forward, around[maxdirection].direction).y < 0 ? -1 : 1);
                //angle *= 180.0f;
            }

            //目的方向へ回転
            Debug.DrawRay(around[maxdirection].origin, around[maxdirection].direction, Color.red);
            if (rotationmove)
            {
                if (angle > 0)
                {
                    angle -= Rotatemovespeed;
                    parent.transform.Rotate(new Vector3(0, Rotatemovespeed, 0));
                    //Debug.Log("angle=" + angle);
                }
                if (angle <= 0)
                {
                    angle += Rotatemovespeed;
                    parent.transform.Rotate(new Vector3(0, -Rotatemovespeed, 0));
                    //Debug.Log("angle=" + angle);
                }
                if (angle < Rotatemovespeed * 2 && -Rotatemovespeed * 2 < angle)
                {
                    rotationmove = false;
                    move = true;
                }
            }

            //目的方向へ移動
            if (move)
            {
                parent.transform.position += parent.transform.forward.normalized * movespeed;
                distancefromobjmax -= movespeed;
                if (distancefromobjmax < 0.5f)
                {
                    move = false;
                    aftermovefirst = true;
                    aftermove = true;
                }
            }

            //動いた後プレイヤーの角度を計算

            if (aftermove)
            {
                //動いた後プレイヤーの角度を計算
                if (aftermovefirst)
                {
                    aftermovefirst = false;
                    angle = Vector3.Angle(this.transform.forward, player.transform.position - this.transform.position) * (Vector3.Cross(this.transform.forward, player.transform.position - this.transform.position).y < 0 ? -1 : 1);
                }

                //プレイヤーの向きへ回転
                if (angle > 0)
                {
                    angle -= Rotatemovespeed;
                    parent.transform.Rotate(new Vector3(0, Rotatemovespeed, 0));
                    //Debug.Log("angle=" + angle);
                }
                if (angle <= 0)
                {
                    angle += Rotatemovespeed;
                    parent.transform.Rotate(new Vector3(0, -Rotatemovespeed, 0));
                    //Debug.Log("angle=" + angle);
                }
                if (angle < Rotatemovespeed * 2 && -Rotatemovespeed * 2 < angle)
                {
                    aftermove = false;
                    escape = false;
                    audiosource[2].Play();
                    escapefirst = true;
                    aftermovefirst = true;
                    rotationmove = true;
                    maxdirection = 0;
                }
                
            }

        }
        else
        {
            escapefirst = true;
            aftermovefirst = true;
            rotationmove = true;
            maxdirection = 0;
        }
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
    /// やられたときの処理 appear=trueで出現、damage=trueでダメージを受ける　体力が0になるとdie=trueになり死亡時の処理を行う
    /// </summary>
    void Defeat()
    {
        if (die)
        {
            transform.Rotate(0, Rotatodiespeed, 0);
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
            die = true;
            damage = false;
        }
    }
}


