using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour {

    //PlayerRootはplayerがいるべき位置（HMDの位置）
    //CameraRigにアタッチする

    //座面（床）がy軸に垂直なことが前提。傾いた状態で使うなら要修正

    [SerializeField] GameObject HMD;

    [SerializeField] GameObject PlayerRoot;

    private Vector3 RootAngle;
    private Vector3 HMDAngleXZ;

    private Quaternion HMD_to_Root_Qua;
    private Vector3 HMD_to_Root_vec;

    private void Start()
    {
        //ResetPos();
        //StartCoroutine("StartReset");
    }

    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            ResetPos();
        }
    }


    //Camerarigをずらして椅子のXZ位置に頭がちょうど来るようにする
    public void ResetPos()
    {
       
            RootAngle = PlayerRoot.transform.forward;
            HMDAngleXZ = new Vector3(HMD.transform.forward.x, 0f, HMD.transform.forward.z);

            HMD_to_Root_Qua = Quaternion.FromToRotation(HMDAngleXZ, RootAngle);

            Debug.Log("Root" + RootAngle + "  HMD" + HMDAngleXZ + "  Euler" + HMD_to_Root_Qua.eulerAngles);
        
            //gameObject.transform.rotation = HMD_to_Root_Qua * gameObject.transform.rotation;
               
            HMD_to_Root_vec = PlayerRoot.transform.position - HMD.transform.position;

            Debug.Log("Root" + PlayerRoot.transform.position + "  HMD" + HMD.transform.position+"  trans"+HMD_to_Root_vec);
               
            gameObject.transform.position = gameObject.transform.position + HMD_to_Root_vec + new Vector3(0, 0.05f, 0);

    }

    public void RecalibrateFloor()
    {
        
    }

    private IEnumerator StartReset()
    {
        yield return new WaitForSeconds(1f);
        ResetPos();
    }

}
