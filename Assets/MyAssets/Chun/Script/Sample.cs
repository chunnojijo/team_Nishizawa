using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample : MonoBehaviour {
    public Transform lightpos;
    public float theta=60.0f;
    public float lightdistance=200.0f;
    public GameObject[] Objects;
    public GameObject[] damagesc;
    public GameObject camerarig;
    
    private RaycastHit hit;
    private Ray ray;
    /*private void OnTriggerStay(Collider other)
    {
        Debug.Log(lightpos);
        ray = new Ray(lightpos.position, other.gameObject.transform.position - lightpos.position);
        //other.gameObject.GetComponent<wireframe>().enabled = false;
        other.gameObject.GetComponent<Renderer>().material.color = Color.white;
        Debug.Log("Objecttag=" + other.gameObject.transform.tag);
        if (Physics.Raycast(ray, out hit, lightdistance) && (Vector3.Dot(transform.TransformDirection(Vector3.forward.normalized), lightpos.forward.normalized) >0.5f) /*&& hit.transform.tag == "object")
        {
            Debug.Log("Transparent");
            if (other.gameObject == hit.collider.gameObject)
            {
                other.gameObject.GetComponent<Renderer>().material.color = Color.red;
                Debug.Log("Find");
            }
        }

    }*/

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        for(int i = 0; i < Objects.Length; i++)
        {
            ray = new Ray(camerarig.transform.position, Objects[i].transform.TransformPoint(damagesc[i].transform.localPosition)- camerarig.transform.position);
            if (Physics.Raycast(ray, out hit, lightdistance) && (Vector3.Dot(camerarig.transform.forward.normalized, ray.direction.normalized) > 0.94f))
            {
                Debug.Log("Find");

                //damagesc[i].GetComponent<Escape>().damage = true;
                if (hit.transform.tag == Objects[i].transform.tag)
                {
                    damagesc[i].GetComponent<Escape>().damage = true;
                    Debug.Log("trueFind");
                }
               /*lse
                {
                    damagesc[i].GetComponent<Escape>().damage = false;
                }*/
            }
            else
            {
                damagesc[i].GetComponent<Escape>().damage = false;
            }

        }
        
	}
}
