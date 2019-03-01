using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private Vector3 DefScale;

    bool canVanish = false;
    
    private RaycastHit hit;
    private Ray ray;
    [SerializeField] float lightdistance = 50f;
    [SerializeField] Transform player;

    bool IsDamaging = false;
    float HP = 5f;
    Quaternion DefRot;

    [SerializeField] EndingTutrial endingTutrial;


    // Use this for initialization
    void Start () {
      //  renderer = gameObject.GetComponent<MeshRenderer>();
        DefScale = gameObject.transform.localScale;
        Invoke("Can", 3f);
        DefRot = gameObject.transform.rotation;
        	
	}
	
	// Update is called once per frame
	void Update () {

        if (exists && canVanish)
        {

            ray = new Ray(player.position, heartPos.position - player.position);
            if (Physics.Raycast(ray, out hit, lightdistance) && (Vector3.Dot(player.forward.normalized, ray.direction.normalized) > 0.9f))
            {
                Debug.Log("Find");

                //damagesc[i].GetComponent<Escape>().damage = true;
                if (hit.transform.tag == heartPos.tag)
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

                }

            }
            else
            {
                StopDamage();
            }

        }

        if (IsDamaging)
        {
            HP -= Time.deltaTime;
            Debug.Log(HP);
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

            gameObject.transform.localScale = Rate * DefScale;
            gameObject.transform.Rotate(0f,0f, 540f * Time.deltaTime);
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

    }

    void Can()
    {
        canVanish = true;
    }

    void StartDamage()
    {
        if (IsDamaging) { return; }
        iTween.ShakeRotation(gameObject, new Vector3(1, 1, 1), 5f);
        IsDamaging = true;       
    }

    void StopDamage()
    {
        if (!IsDamaging) { return; }

        iTween.Stop(gameObject, "shake");
        gameObject.transform.rotation = DefRot;
        IsDamaging = false;
    }

}
