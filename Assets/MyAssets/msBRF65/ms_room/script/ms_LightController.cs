using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ms_LightController : MonoBehaviour {
    private bool lock_light = true,finish_color = false;
    public GameObject shadow_light,player,image;
    float lighted_time, distance = 3f, color = 255f;
    public float color_speed = 3f;
    Ray player_ray;
    RaycastHit hit;

	// Use this for initialization
	void Start () {
        this.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Physics.Raycast(player.transform.position,player.transform.forward, distance))
        {
            color -= Time.deltaTime * color_speed;
            
            //Rayが当たったオブジェクトのtagがPlayerだったら
            if (hit.collider.tag == "image" && !finish_color)
            {
                if (color < 0f)
                {
                    color = 0f;
                    finish_color = true;
                    shadow_light.SetActive(true);
                }
                image.GetComponent<Image>().color = new Color(color, 0f, 0f);
            }
        }
    }

}
