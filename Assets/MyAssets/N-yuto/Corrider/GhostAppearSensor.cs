using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAppearSensor : MonoBehaviour {

    Escape escape;
    [SerializeField] OpeningTutrial opening;

    // Use this for initialization
    void Start()
    {
        escape = gameObject.GetComponent<Escape>();

    }

    // Update is called once per frame
    void Update()
    {
        if (escape.appear)
        {
            opening.OP04_CanContinue = true;
        }
    }
}
