using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CC_MVCtrl_Edit : MonoBehaviour
{

    public float FrontSpeed;
    public float RightSpeed;
    public float UpSpeed;
    [Space]
    public float rotateSpeed = 90.0f;
    public float gravity = 10f;
    public float jumpPower = 5;

    private Vector3 moveDirection = new Vector3(0f, 0f, 0f);
    private CharacterController controller;

    [SerializeField] float MaxSpeed = 3f;
    [SerializeField] float acceralation = 1f;
    [SerializeField] float StopCoefficient = 3f;

    Vector2 StickL;

    [SerializeField] bool Is_VR_Mode;


    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Is_VR_Mode)
        {
            StickL = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick);
        }
        else
        {
            StickL = new Vector2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
        }

        if (controller.isGrounded)
        {
            if (UpSpeed < 0f)
            {//下向き速度０に
                UpSpeed = 0f;
            }

            if(StickL.x >= 0.1f)//前進
            {
                if (FrontSpeed < 0f)
                {
                    FrontSpeed = 0f;
                }

                if (FrontSpeed <= MaxSpeed)
                {
                    FrontSpeed += acceralation * StickL.x * Time.deltaTime;
                }

            }
            else if(StickL.x > -0.1f)//Stay
            {
                if (FrontSpeed <= -MaxSpeed * 0.25f)
                {
                    FrontSpeed += acceralation * StopCoefficient * Time.deltaTime;
                }
                else if (FrontSpeed >= MaxSpeed * 0.25f)
                {
                    FrontSpeed -= acceralation * StopCoefficient * Time.deltaTime;
                }
                else
                {
                    FrontSpeed = 0f;
                }
            }
            else//後退
            {
                if (FrontSpeed > 0f)
                {
                    FrontSpeed = 0f;
                }

                if (FrontSpeed >= -MaxSpeed)
                {
                    FrontSpeed += acceralation * StickL.x * Time.deltaTime;
                }

            }


            if (StickL.y >= 0.1f)//右
            {
                if (RightSpeed < 0f)
                {
                    RightSpeed = 0f;
                }

                if (RightSpeed <= MaxSpeed)
                {
                    RightSpeed += acceralation * StickL.y * Time.deltaTime;
                }

            }
            else if (StickL.y > -0.1f)//Stay
            {
                if (RightSpeed <= -MaxSpeed * 0.25f)
                {
                    RightSpeed += acceralation * StopCoefficient * Time.deltaTime;
                }
                else if (RightSpeed >= MaxSpeed * 0.25f)
                {
                    RightSpeed -= acceralation * StopCoefficient * Time.deltaTime;
                }
                else
                {
                    RightSpeed = 0f;
                }
            }
            else//左
            {
                if (RightSpeed > 0f)
                {
                    RightSpeed = 0f;
                }

                if (RightSpeed >= -MaxSpeed)
                {
                    RightSpeed += acceralation * StickL.y * Time.deltaTime;
                }

            }


        }
        else//空中
        {
            UpSpeed -= gravity * Time.deltaTime;
        }

        //回転
        if (Is_VR_Mode)
        {

            if (OVRInput.GetDown(OVRInput.RawButton.RThumbstickLeft))
            {
                iTween.RotateAdd(this.gameObject, -Vector3.up * 45f, 0.5f);
            }
            if (OVRInput.GetDown(OVRInput.RawButton.RThumbstickRight))
            {
                iTween.RotateAdd(this.gameObject, Vector3.up * 45f, 0.5f);
            }

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                iTween.RotateAdd(this.gameObject, -Vector3.up * 45f, 0.5f);
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                iTween.RotateAdd(this.gameObject, Vector3.up * 45f, 0.5f);
            }

        }

        moveDirection = new Vector3(RightSpeed, UpSpeed,FrontSpeed);
        controller.Move(Quaternion.LookRotation(transform.forward,Vector3.up) * moveDirection);
    }
    void OnControllerTriggerHit(ControllerColliderHit Hit)
    {
        //CharacterController側の衝突判定はOnCollisionEnter等でなくて、これを用いる
    }


}