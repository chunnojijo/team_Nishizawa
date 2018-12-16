using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour {
    Vector3 Camera_Vec;
    public GameObject Camera;
    public float speed = 2f, y_rotate=0f;

	// Use this for initialization
	void Start () {
        
	}

	
	// Update is called once per frame
	void Update () {
        Camera_Vec = Camera.transform.forward;
        if (Input.GetKey("up"))
        {
            Camera_Vec = Get_xzVec(Camera.transform.forward);
            this.transform.position += Camera_Vec*speed*Time.deltaTime;
        }
        else if (Input.GetKey("down"))
        {
            Camera_Vec = Get_xzVec(Camera.transform.forward);
            this.transform.position += Quaternion.Euler(0f, 180f, 0f)* Camera_Vec * speed * Time.deltaTime;
        }
        else if (Input.GetKey("right"))
        {
            Camera_Vec = Get_xzVec(Camera.transform.forward);
            this.transform.position += Quaternion.Euler(0f, 90, 0f) * Camera_Vec * speed * Time.deltaTime;
        }
        else if (Input.GetKey("left"))
        {
            Camera_Vec = Get_xzVec(Camera.transform.forward);
            this.transform.position += Quaternion.Euler(0f,-90, 0f) * Camera_Vec * speed * Time.deltaTime;
        }
        if (y_rotate >= 360f)
        {
            y_rotate -= 360f;
        }
        else if (y_rotate < 0)
        {
            y_rotate += 360f;
        }
    }

    Vector3 Get_xzVec(Vector3 forward)
    {
        float x = forward.x;
        float z = forward.z;
        return new Vector3(x, 0f, z).normalized;
    }
}
