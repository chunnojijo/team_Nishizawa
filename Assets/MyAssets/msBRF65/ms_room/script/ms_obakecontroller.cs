using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ms_obakecontroller : MonoBehaviour {
    public bool finish = false;
    public GameObject obake, player;
    float lighted_time, distance = 3f;
    public float time = 2f;
    Ray player_ray;
    RaycastHit hit;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        player_ray = new Ray(player.transform.position, player.transform.forward);

        if (Physics.Raycast(player_ray, out hit, distance) && !finish)
        {
            //Debug.LogWarning(hit.transform.name);
            //Destroy(hit.collider);

            //Rayが当たったオブジェクトのtagがimageだったら
            if (hit.collider.tag == "image" && !finish)
            {
                time -= Time.deltaTime;
                if (time < 0f)
                {
                    finish = true;
                    this. 
                    obake.SetActive(true);
                }
            }
        }
    }
}
