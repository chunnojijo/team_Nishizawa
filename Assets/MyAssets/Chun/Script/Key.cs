using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

    public float floatwidth = 0.5f;
    public float floatspeed = 5f;
    public float scaleSpeed = 0.05f;
    public bool getstatus = false;

    private bool alldie=false;
    private int lastdienum = -1;
    private float time=0;
    private float timeafterapper=0;
    
    [SerializeField]
    private GameObject[] Ghost;
    [SerializeField]
    private GameObject Player;
    // Use this for initialization

    /*private void OnTriggerEnter(Collider other)
    {
        getstatus = true;
        this.GetComponent<MeshRenderer>().enabled = false;
    }*/
    
    void Start () {
        this.GetComponent<MeshRenderer>().enabled = false;
        this.transform.localScale = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
        alldie = true;
        for(int i = 0; i < Ghost.Length; i++)
        {
            if (!Ghost[i].GetComponent<Escape>().dieatall)
            {
                alldie = false;
                if (i != lastdienum)
                {
                    lastdienum = i;
                    //Debug.Log("LastDieNum=" + lastdienum);
                }
            }
        }
        if (alldie)
        {
            if(!getstatus)this.GetComponent<MeshRenderer>().enabled = true;
            this.transform.position = Ghost[lastdienum].transform.root.transform.position;
            if (this.transform.localScale.x < 0.05f) this.transform.localScale += new Vector3(scaleSpeed * Time.deltaTime, scaleSpeed * Time.deltaTime, scaleSpeed * Time.deltaTime);
            timeafterapper += Time.deltaTime;
        }
        /*time += Time.deltaTime;
        transform.position += new Vector3(0, floatwidth * (Mathf.Sin(time * floatspeed) - Mathf.Sin((time - Time.deltaTime) * floatspeed)), 0);*/
        //Debug.Log("Distance=" + (Player.transform.position - this.transform.position).magnitude);
        if ((Player.transform.position - this.transform.position).magnitude < 0.5f&&timeafterapper>1.0f)
        {
            getstatus = true;
            this.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
