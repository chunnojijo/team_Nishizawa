
using UnityEngine;
using System.Collections;

public class WLDebug : MonoBehaviour
{

    public Transform parent;
    public Transform child;

    // Use this for initialization
    void Update()
    {
        //　ワールド空間でのデータ
        Debug.Log("ParentWorld:" + parent.position + "|" + parent.eulerAngles + "|" + parent.lossyScale);
        Debug.Log("ChildWorld:" + child.position + "|" + child.eulerAngles + "|" + child.lossyScale);

        //　ローカル空間でのデータ
        Debug.Log("ParentLocal:" + parent.localPosition + "|" + parent.localEulerAngles + "|" + parent.localScale);
        Debug.Log("ChildLocal:" + child.localPosition + "|" + child.localEulerAngles + "|" + child.localScale);
    }
}