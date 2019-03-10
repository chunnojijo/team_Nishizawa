using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CC_MoveController : MonoBehaviour {
    public float Horizontal = 40f, Vertical = 40f, y_rotate = 0;
    Vector3 H_Vector = new Vector3(0f, -1f, 0f), V_Vector = new Vector3(-1f, 0f, 0f);
    public float speed = 20.0f;
    public float rotateSpeed = 20.0f;
    public float gravity = 10f;
    public float jumpPower = 5;

    private Vector3 moveDirection= new Vector3(0f,0f,0f);
    private CharacterController controller;

	// Use this for initialization
	void Start () {
        controller=GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (controller.isGrounded)
        {
            if (moveDirection.y < 0f)
            {
                moveDirection.y = 0f;
            }
            if (Input.GetKey("a"))
            {
                this.transform.Rotate(H_Vector * Horizontal * Time.deltaTime, Space.World);
                y_rotate -= Horizontal * Time.deltaTime;
            }
            else if (Input.GetKey("d"))
            {
                this.transform.Rotate(-1 * H_Vector * Horizontal * Time.deltaTime, Space.World);
                y_rotate += Horizontal * Time.deltaTime;
            }
            else if (Input.GetKey("w"))
            {
                this.transform.Rotate(V_Vector * Vertical * Time.deltaTime);
            }
            else if (Input.GetKey("s"))
            {
                this.transform.Rotate(-V_Vector * Vertical * Time.deltaTime);
            }
            if (Input.GetKey("up"))
            {
                moveDirection = transform.transform.forward * speed * Time.deltaTime;
            }
            else if (Input.GetKey("down"))
            {
                moveDirection = -transform.transform.forward * speed *Time.deltaTime;
            }
            else if (Input.GetKey("right"))
            {
                moveDirection = Quaternion.Euler(0f, 90f, 0f) * transform.transform.forward * speed * Time.deltaTime;
            }
            else if (Input.GetKey("left"))
            {
                moveDirection = Quaternion.Euler(0f, -90f, 0f) * transform.transform.forward * speed * Time.deltaTime;
            }
            else
            {
                moveDirection = Vector3.zero;
            }
            if (Input.GetKey("space"))
            {
                moveDirection.y = jumpPower;
            }
        }
        else
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        controller.Move(moveDirection * Time.deltaTime);
	}
    void OnControllerTriggerHit(ControllerColliderHit Hit)
    {
        //CharacterController側の衝突判定はOnCollisionEnter等でなくて、これを用いる
    }
}
