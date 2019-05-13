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
    public bool escapeflag = true;
    public float maxEnemyHP = 3;
    public float escapetime = 1;
    public float Rotatemovespeed = 0.5f;
    public float movespeed = 0.1f;
    public float escapedistance = 5.0f;
    public bool dieatall = false;
    public GameObject Heart;
    public GameObject changeObject;//変身元のオブジェクトを入れる　ない場合はNone
    public Vector3 Object_finalscale=new Vector3(10.0f,10.0f,10.0f);
    public float damagingspeed = 0.3f;
    public float changespeed = 1;

    private bool escapefirst = true;
    private bool die = false;
    private bool apfirst = true;
    private bool damagefirst = false;
    private bool moveslide=true;
    private bool rotationmove = true;
    private bool move = false;
    private bool aftermovefirst = false;
    private bool aftermove = false;
    private bool escapefirstfinish = false;
    private bool escapegoto=false;
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
    private float DamagingSpeedDefault;
    private Vector3 changeObject_firstscale;
    private OVRHapticsClip hapticsClip;
    [SerializeField]
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
    [SerializeField]
    private bool appear_from_other_script;
    [SerializeField]
    private GameObject SliderBackGround;
    [SerializeField]
    private GameObject SliderFill;

    void Start () {
        DamagingSpeedDefault = damagingspeed;
        audiosource = this.GetComponents<AudioSource>();
        particlesystem = this.GetComponentsInChildren<ParticleSystem>();
        GetComponent<MeshRenderer>().enabled = false;
        Heart.GetComponent<MeshRenderer>().enabled = false;
        slider.maxValue = maxEnemyHP;
        slider.gameObject.SetActive(false);
        enemyHP = maxEnemyHP;
        distancefromobj = new float[8];
        around = new Ray[8];
        //parent = this.transform.root.gameObject;
        Object_finalscale = new Vector3(10.0f, 10.0f, 10.0f); byte[] samples = new byte[8];
        for (int i = 0; i < samples.Length; i++)
        {
            samples[i] = 128;
        }
        hapticsClip = new OVRHapticsClip(samples, samples.Length);

        SliderBackGround = gameObject.transform.parent.Find("Canvas/Slider/Background").gameObject;
        SliderFill = gameObject.transform.parent.Find("Canvas/Slider/Fill Area/Fill").gameObject;
    }
	

	// Update is called once per frame
	void Update () {

        if (damage) damagingspeed = DamagingSpeedDefault;
        else damagingspeed = 1;
        //For Debug
        if (Input.GetKeyDown(KeyCode.A)) appear = true;
        if (Input.GetKeyDown(KeyCode.E)) escape = true;
        if (Input.GetKeyDown(KeyCode.D) && !damage) damage = true;
        else if (Input.GetKeyDown(KeyCode.D)) damage = false;
        //For Debug
        GetComponent<Renderer>().material.SetFloat("_Alpha", (1+Mathf.Sin(Time.realtimeSinceStartup * changespeed))/2.0f);
        SliderBackGround.GetComponent<Image>().color = new Color(SliderBackGround.GetComponent<Image>().color.r, SliderBackGround.GetComponent<Image>().color.g, SliderBackGround.GetComponent<Image>().color.b,(1 + Mathf.Sin(Time.realtimeSinceStartup * changespeed)) / 2.0f );

        SliderFill.GetComponent<Image>().color = new Color(SliderFill.GetComponent<Image>().color.r, SliderFill.GetComponent<Image>().color.g, SliderFill.GetComponent<Image>().color.b, (1 + Mathf.Sin(Time.realtimeSinceStartup * changespeed)) / 2.0f );



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

        if (damage && !dieatall && this.GetComponent<Renderer>().enabled) 
        {
            OVRHaptics.LeftChannel.Mix(hapticsClip);
            Debug.Log("振動");
        }

        

        Defeat();
       
	}



    /// <summary>
    /// やられたときと出現時の処理 appear=trueで出現、damage=trueでダメージを受ける　体力が0になるとdie=trueになり死亡時の処理を行う
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
                damageparticle.Stop();
                GetComponent<MeshRenderer>().enabled = false;
                /*escape = false;
                damage = false;
                moveslide = false;
                move = false;
                aftermove = false;*/
                die = false;
                dieatall = true;
                //Destroy(this);
            }
            slider.gameObject.SetActive(false);
        }

        //変身するものがなく，かつ出現条件がほかのスクリプトに依存しない場合　出現判定
        if ((player.transform.position - parent.transform.position).magnitude < 5 && apfirst && changeObject == null&&!appear_from_other_script)
        {
            appear = true;
        }

        

        //変身する者がある場合　出現判定
        if (damage && apfirst && changeObject != null)
        {
            watchedtime += Time.deltaTime;
            if (watchedtime > 1.0f)
            {
                appear = true;
            }
        }

        //変身する者がない場合出現処理
        if (appear && changeObject == null)
        {
            if (apfirst)
            {
                transform.localScale = new Vector3(0, 0, 0);
                smokeparticle.Play();
                audiosource[1].Play();
                apfirst = false;
                GetComponent<MeshRenderer>().enabled = true;
                Heart.GetComponent<MeshRenderer>().enabled = true;
                slider.gameObject.SetActive(true);
            }
            if (transform.localScale.x < 10) transform.localScale += new Vector3(Scalespeed, Scalespeed, Scalespeed);
            if (transform.localScale.x >= 10)
            {
                appear = false;
            }
        }
        //変身するものがある場合出現処理
        if (appear && changeObject != null)
        {
            if (apfirst)
            {
                transform.localScale = new Vector3(0, 0, 0);
                smokeparticle.Play();
                audiosource[1].Play();
                apfirst = false;
                GetComponent<MeshRenderer>().enabled = true;
                Heart.GetComponent<MeshRenderer>().enabled = true;
                slider.gameObject.SetActive(true);
                changeObject_firstscale = changeObject.transform.localScale;
                Object_finalscale = this.transform.localScale;
            }
            if (transform.localScale.x < 10)
            {
                transform.localScale += new Vector3(Scalespeed, Scalespeed, Scalespeed);
                //Debug.Log("Change!" + Object_finalscale.x);
                changeObject.transform.localScale -= new Vector3(changeObject_firstscale.x / 10.0f * Scalespeed, changeObject_firstscale.y / 10.0f * Scalespeed, changeObject_firstscale.z / 10.0f * Scalespeed);
            }
            if (transform.localScale.x >= 10)
            {
                appear = false;
                escapegoto = true;
            }
        }

        //左が変身する者がない場合、右が変身する者がある場合のダメージ判定　中身はダメージ処理
        if ((damage && !apfirst && !dieatall))
        {
            if (!damagefirst)
            {
                damageparticle.gameObject.SetActive(true);
                damageparticle.Play();
                Debug.Log("damage");
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
        

        if (enemyHP <= 0 && !dieatall)
        {
            die = true;
            damage = false;
        }
    }



    
    /// <summary>
    /// プレイヤーから逃げる処理　escape=trueで逃げる処理が始まる
    /// </summary>
    void Escapefromplayer()
    {
        if (escapeflag)
        {
            if ((escape  && !apfirst && !dieatall) || escapegoto)
            {

                //escapeに入ったとき最初だけ行う処理
                if (escapefirst && !damage)
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
                if (rotationmove /*&& !damage*/)
                {
                    if (angle > 0)
                    {
                        angle -= Rotatemovespeed*damagingspeed;
                        parent.transform.Rotate(new Vector3(0, Rotatemovespeed*damagingspeed, 0));
                        //Debug.Log("angle=" + angle);
                    }
                    if (angle <= 0)
                    {
                        angle += Rotatemovespeed*damagingspeed;
                        parent.transform.Rotate(new Vector3(0, -Rotatemovespeed*damagingspeed, 0));
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
                    if (distancefromobjmax > 1.0f)
                    {
                        if (!damage) parent.transform.position += parent.transform.forward.normalized * movespeed;
                        else parent.transform.position += parent.transform.forward.normalized * movespeed * damagingspeed;
                    }
                    if (!damage) distancefromobjmax -= movespeed;
                    else distancefromobjmax -= movespeed * damagingspeed;
                    if (distancefromobjmax < 0.5f)
                    {
                        move = false;
                        aftermovefirst = true;
                        aftermove = true;
                    }
                }

                //動いた後プレイヤーの角度を計算

                if (aftermove /*&& !damage*/)
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
                        angle -= Rotatemovespeed*damagingspeed;
                        parent.transform.Rotate(new Vector3(0, Rotatemovespeed*damagingspeed, 0));
                        //Debug.Log("angle=" + angle);
                    }
                    if (angle <= 0)
                    {
                        angle += Rotatemovespeed*damagingspeed;
                        parent.transform.Rotate(new Vector3(0, -Rotatemovespeed*damagingspeed, 0));
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
                        escapefirstfinish = true;
                        escapegoto = false;
                        maxdirection = 0;
                    }

                }

            }
            else
            {
                if (/*!damage*/true)
                {
                    escapefirst = true;
                    aftermovefirst = true;
                    rotationmove = true;
                    maxdirection = 0;
                }
            }
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

    
}


