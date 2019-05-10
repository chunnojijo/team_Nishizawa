using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitychanUIManager : MonoBehaviour {

    [SerializeField] Animator animator;
    [SerializeField] RawImage imageWindow;

    Vector3 ScaleR;
    Vector3 ScaleL;

    private void Start()
    {
        ScaleR = imageWindow.transform.localScale;
        ScaleL = new Vector3(-ScaleR.x, ScaleR.y, ScaleR.z);
    }

    public void ShowStickR()
    {
        animator.SetTrigger("Stick2way");
        imageWindow.transform.localScale = ScaleR;
    }
    public void ShowStickL()
    {
        animator.SetTrigger("Stick4way");
        imageWindow.transform.localScale = ScaleL;
    }
    public void ShowTriggerR()
    {
        animator.SetTrigger("Trigger");
        imageWindow.transform.localScale = ScaleR;
    }

}
