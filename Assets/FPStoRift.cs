using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPStoRift : MonoBehaviour
{


    private float x;
    private float y;
    private Vector3 cameravecforward;
    private Vector3 cameravecright;
    public Vector3 moveDirection;
    // Use this for initialization
    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.x;
        y = angles.y;

    }

    // Update is called once per frame
    void Update()
    {
        x += OVRInput.Get(OVRInput.RawAxis2D.LThumbstick).x * 1.5f;
        y -= OVRInput.Get(OVRInput.RawAxis2D.LThumbstick).y * 1.5f;
        y = Mathf.Clamp(y, -20, 80);
        transform.rotation = Quaternion.Euler(y, x, 0);


        cameravecforward = this.transform.TransformDirection(Vector3.forward).normalized;
        cameravecforward = new Vector3(cameravecforward.x, 0, cameravecforward.z).normalized;
        cameravecright = new Vector3(cameravecforward.z, 0, -cameravecforward.x).normalized;
        //moveDirection = cameravecforward * (-Input.GetAxis("Axis 2")) + cameravecright * Input.GetAxis("Axis 1");
        moveDirection = cameravecforward * (Input.GetAxis("Vertical")) + cameravecright * Input.GetAxis("Horizontal");
        this.transform.position += moveDirection * 0.03f;
    }
}