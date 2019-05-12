using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalAvatorMoveMayFes : MonoBehaviour
{
    [SerializeField] bool IsDebugging;
    [Space(10)]

    public float movespeedcontroller;
    [SerializeField]
    private float controllermovevalue = 3;
    [SerializeField]
    private float movespeed;
    [SerializeField]
    private GameObject handright;
    [SerializeField]
    private GameObject camerarig;
    private bool bef_move_sign;
    private bool move_sign;
    private Vector3 befpos;
    private float controllermove;
    private Vector2 stickL;
    private Vector3 movestick;

    CharacterController CC;

    // Use this for initialization
    void Start()
    {
        CC = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        move_sign = (handright.transform.position - befpos).y > 0;
        controllermove += (handright.transform.position - befpos).y;
        if (bef_move_sign != move_sign)
        {
            controllermove = 0;
        }

        if (controllermove > controllermovevalue || controllermove < -controllermovevalue)
        {
            StartCoroutine("move");
        }



        bef_move_sign = move_sign;
        befpos = handright.transform.position;
        if (OVRInput.GetDown(OVRInput.RawButton.RThumbstickLeft))
        {
            this.transform.Rotate(new Vector3(0, -22.5f, 0));
        }
        if (OVRInput.GetDown(OVRInput.RawButton.RThumbstickRight))
        {
            this.transform.Rotate(new Vector3(0, 22.5f, 0));
        }
        if (!this.GetComponent<CharacterController>().isGrounded)
        {
            this.GetComponent<CharacterController>().Move(new Vector3(0, -3 * Time.deltaTime, 0));
        }
        stickL = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick);
        Debug.Log(stickL.x + stickL.y);
        movestick = (stickL.y * camerarig.transform.forward.normalized + stickL.x * camerarig.transform.right.normalized) * movespeedcontroller;
        this.GetComponent<CharacterController>().Move(movestick * Time.deltaTime);
    }

    IEnumerator move()
    {
        if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger))
        {
            CC.Move(new Vector3((camerarig.transform.forward * movespeed * Time.deltaTime).x, 0, (camerarig.transform.forward * movespeed * Time.deltaTime).z));
        }

        yield return new WaitForSeconds(0.7f);
    }
}
