using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerMove : MonoBehaviour {
    // ターゲットオブジェクトの Transform を格納する変数
    //public Transform target;
    // ターゲットオブジェクトの座標からオフセットする値
    public float offset;

    public GameObject hand;

    private void Start()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerHand") && OVRInput.Get(OVRInput.RawButton.RHandTrigger))
        {
            Follow();
        }
    }

    // ゲーム実行中の処理（Update処理後）
    private void Follow()
    {
        // オブジェクトの座標を変数 pos に格納
        Vector3 pos = transform.position;
        // ターゲットオブジェクトのX座標に変数 offset のオフセット値を加えて
        // 変数 posXの座標に代入
        pos.x = hand.transform.position.x + offset;
        // 変数 pos の値をオブジェクト座標に格納
        transform.position = pos;
    }
}
