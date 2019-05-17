using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalAvatorMove : MonoBehaviour {
    public float movespeedcontroller;
    [SerializeField]
    private float controllermovevalue=3;
    [SerializeField]
    private float movespeed;
    [SerializeField]
    private GameObject handright;
    [UnityEngine.Serialization.FormerlySerializedAs("camerarig")]
    [SerializeField]
    private GameObject HMD;//centerEyeAnchor
    private bool bef_move_sign;
    private bool move_sign;
    private Vector3 befpos;
    private float controllermove;
    private Vector2 stickL;
    private Vector3 movestick;

    CharacterController CC;

	// Use this for initialization
	void Start () {
        CC = this.GetComponent<CharacterController>();

    }
	
	// Update is called once per frame
	void Update () {

        move_sign = (handright.transform.position - befpos).y > 0;
        controllermove += (handright.transform.position - befpos).y;
        if (bef_move_sign != move_sign)
        {
            controllermove = 0;
        }

        if (controllermove > controllermovevalue||controllermove<-controllermovevalue)
        {
            StartCoroutine("move");
        }


        bef_move_sign =move_sign;
        befpos = handright.transform.position;
        if (OVRInput.GetDown(OVRInput.RawButton.RThumbstickLeft))
        {
            transform.RotateAround(transform.TransformPoint(CC.center),Vector3.up,-22.5f);
        }
        if (OVRInput.GetDown(OVRInput.RawButton.RThumbstickRight))
        {
            transform.RotateAround(transform.TransformPoint(CC.center), Vector3.up,22.5f);
        }
        if (!CC.isGrounded)
        {
            CC.Move(new Vector3(0, -3 * Time.deltaTime, 0));
        }
        stickL = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick);
        Debug.Log(stickL.x + stickL.y);
        movestick = (stickL.y * HMD.transform.forward + stickL.x * HMD.transform.right) * movespeedcontroller;
        //CC.Move(movestick*Time.deltaTime);
        Quaternion rot = Quaternion.FromToRotation(Vector3.forward, Vector3.ProjectOnPlane(HMD.transform.forward,Vector3.up));
        Vector3 mv = new Vector3(stickL.x,0,stickL.y);
        CC.Move(rot * mv * movespeedcontroller * Time.deltaTime);
    }



    IEnumerator move()
    {
        if (OVRInput.Get(OVRInput.RawButton.RHandTrigger))
        {
            //CC.Move(new Vector3((HMD.transform.forward * movespeed * Time.deltaTime).x, 0f, (HMD.transform.forward * movespeed * Time.deltaTime).z);
            CC.Move(new Vector3((HMD.transform.forward * movespeed * Time.deltaTime).x, 0, (HMD.transform.forward * movespeed * Time.deltaTime).z));
        }
        yield return new WaitForSeconds(0.7f);
    }

}
