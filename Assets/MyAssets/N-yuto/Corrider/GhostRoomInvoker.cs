using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostRoomInvoker : MonoBehaviour {

    private Escape[] escapeScripts;
    [SerializeField] GameObject ParentsOfGhosts;

    bool DONE = false;

	// Use this for initialization
	void Start () {
        escapeScripts = ParentsOfGhosts.GetComponentsInChildren<Escape>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(!DONE && other.tag == "Player")
        {
            StartCoroutine(AppearGhosts());
            DONE = true;
        }
    }

    IEnumerator AppearGhosts()
    {
        for(int i = 0; i < escapeScripts.Length; i++)
        {
            escapeScripts[i].appear = true;
            yield return null;
        }

        yield break;
    }
}
