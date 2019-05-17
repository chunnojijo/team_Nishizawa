using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vanishing : MonoBehaviour {

    //private MeshRenderer renderer;
    [SerializeField] private GameObject GhostsParticles;
    [SerializeField] private GameObject SmokeParticles;
    [SerializeField] private GameObject MansionMesh;
    [SerializeField] private GameObject Heart;

    [SerializeField] private Transform heartPos;
    

    private bool IsVanishing = false;
    private bool exists = true;
    [Range(0f,1f)] private float Rate = 1;
    [SerializeField] float TimeToFadeOut = 1f;

    [SerializeField] AnimationCurve curve;

    private Vector3 DefScale;

    bool canVanish = false;
    
    private RaycastHit hit;
    private Ray ray;
    [SerializeField] float lightdistance = 50f;
    [SerializeField] Transform light;

    bool IsDamaging = false;
    [SerializeField] float HP = 5f;
    Quaternion DefRot;

    [SerializeField] EndingTutrial endingTutrial;

    [Space(1)]
    [SerializeField, Range(0f, 1f)] float dissolve;
    [SerializeField] Material[] mats;

    [Space(1)]
    [SerializeField] ParticleSystem DamageParticle;
    [SerializeField] Slider HPSlider;
    AudioSource audio;
    private OVRHapticsClip hapticsClip;



    // Use this for initialization
    void Start () {
      //  renderer = gameObject.GetComponent<MeshRenderer>();
        DefScale = gameObject.transform.localScale;
        Invoke("Can", 3f);
        DefRot = gameObject.transform.rotation;
        HPSlider.maxValue = HP;
        audio = GetComponent<AudioSource>();
        byte[] samples = new byte[8]{128,128,128,128,128,128,128,128};
        hapticsClip = new OVRHapticsClip(samples, samples.Length);

    }

    private void ChangeDissolveRate(float rate)
    {
        foreach (Material mat in mats)
        {
            mat.SetFloat("_Threshold", rate);
        }
    }

    private void OnValidate()
    {
        ChangeDissolveRate(dissolve);
    }

    // Update is called once per frame
    void Update () {

        if (exists && canVanish)
        {

            ray = new Ray(light.position, light.forward);
            Debug.DrawRay(ray.origin,ray.direction,Color.red);
            if (Physics.Raycast(ray, out hit, lightdistance) && (Vector3.Dot(heartPos.position - light.position, ray.direction) > 0.95f))
            {
                Debug.LogWarning("Find" + " dot = " + Vector3.Dot(light.up, ray.direction));

                //damagesc[i].GetComponent<Escape>().damage = true;
                if (hit.transform.tag == "Heart")
                {
                    if(HP <= 0f) {
                          Vanish();
                          exists = false;
                          Debug.Log("Vanish");
                    }
                    else
                    {
                        StartDamage();

                    }

                }else
                {
                    StopDamage();
                }

            }else
                {
                    StopDamage();
                }
            

        }

        if (IsDamaging)
        {
            HP -= Time.deltaTime;
            HPSlider.value = HP;
            Debug.Log(HP);
            OVRHaptics.LeftChannel.Mix(hapticsClip);

        }


        if (IsVanishing)
        {
            //renderer.material.color = new Color(1, 1, 1, alpha);
            Rate -= Time.deltaTime / TimeToFadeOut;

            if (Rate <= 0)
            {
                Rate = 0f;
                //        renderer.enabled = false;
                MansionMesh.SetActive(false);
                Heart.SetActive(false);
                IsVanishing = false;
            }

            //5/4追記
            //ChangeDissolveRate(1-Rate);

            gameObject.transform.localScale = curve.Evaluate(Rate) * DefScale;
            gameObject.transform.Rotate(0f,0f, 360f * Time.deltaTime);
            //5/4追記ここまで


            //   GhostsParticles.transform.localScale = (1 - Rate) * new Vector3(1,1,1);

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vanish();
        }
		
	}

    private void OnTriggerStay(Collider other)
    {

        if (exists && other.tag == "EYE") Vanish();
    }

    void Vanish()
    {
        StopDamage();
        IsVanishing = true;
        exists = false;
        //renderer.enabled = false;
       // GhostsParticles.transform.localScale = Vector3.zero;
        GhostsParticles.SetActive(true);
        SmokeParticles.SetActive(true);
        endingTutrial.ED02_GetReady();
        audio.PlayDelayed(5.5f);
    }

    void Can()
    {
        canVanish = true;
    }

    void StartDamage()
    {
        if (IsDamaging) { return; }
        HPSlider.gameObject.SetActive(true);
        iTween.ShakeRotation(gameObject, Vector3.one * 0.05f, 5f);
        DamageParticle.Play();
        IsDamaging = true;       
    }

    void StopDamage()
    {
        if (!IsDamaging) { return; }
        DamageParticle.Stop();
        iTween.Stop(gameObject, "shake");
        gameObject.transform.rotation = DefRot;
        IsDamaging = false;
    }

}
