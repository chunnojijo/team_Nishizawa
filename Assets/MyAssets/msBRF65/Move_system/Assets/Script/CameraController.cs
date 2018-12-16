using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    // Use this for initialization
    public float Horizontal = 20f,Vertical=20f;
    Vector3 H_Vector = new Vector3(0f, -1f, 0f), V_Vector = new Vector3(-1f, 0f, 0f);
    MoveController Move_Con;
	void Start () {
        Move_Con = this.GetComponent<MoveController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("a"))
        {
            this.transform.Rotate(H_Vector * Horizontal * Time.deltaTime,Space.World);
            Move_Con.y_rotate -= Horizontal * Time.deltaTime;
        }
        else if (Input.GetKey("d"))
        {
            this.transform.Rotate(-1*H_Vector*Horizontal * Time.deltaTime,Space.World);
            Move_Con.y_rotate += Horizontal * Time.deltaTime;
        }
        else if (Input.GetKey("w"))
        {
            this.transform.Rotate(V_Vector * Vertical * Time.deltaTime);
        }
        else if (Input.GetKey("s"))
        {
            this.transform.Rotate(-1* V_Vector * Vertical * Time.deltaTime);
        }
    }
}
