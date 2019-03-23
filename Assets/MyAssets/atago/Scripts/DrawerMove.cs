using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerMove : MonoBehaviour {
    
    public float offset = 0.1f;

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

    private void Follow()
    {
        Vector3 pos = transform.position;
        pos.x = hand.transform.position.x + offset;
        transform.position = pos;
    }
}
