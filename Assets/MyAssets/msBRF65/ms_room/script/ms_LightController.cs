using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ms_LightController : MonoBehaviour {
    private bool lock_light = true;
    public bool finish_color = false;
    public GameObject shadow_light,player,image;
    //playerをlightに変換する
    float lighted_time, distance = 3f, color = 255f, speed;
    public float color_speed = 10f,image_length;
    Ray player_ray;
    RaycastHit hit;

	// Use this for initialization
	void Start () {
        //this.gameObject.SetActive(false);
        image_length = image.transform.localScale.z;
        speed = image_length * Time.deltaTime/10f;
	}
	
	// Update is called once per frame
	void Update () {
        player_ray = new Ray(player.transform.position, player.transform.forward);
        
        if (Physics.Raycast(player_ray, out hit, distance) && image.activeSelf)
        {
            //Debug.LogWarning(hit.transform.name);
            //Destroy(hit.collider);
            
            //Rayが当たったオブジェクトのtagがimageだったら
            if (hit.collider.tag == "image" && !finish_color)
            { 
                /*
                color -= Time.deltaTime * color_speed;
                if (color < 0f)
                {
                    color = 0f;
                    finish_color = true;
                    shadow_light.SetActive(true);
                }
                Debug.Log(image.GetComponent<Renderer>().material.color);
                image.GetComponent<Renderer>().material.color = new Color(color, 255f, 255f);
                */
                //color_speedの時間で終わる
                if(!finish_color){
                    if (image.transform.localScale.z < speed)
                    {
                        image.transform.localScale -= new Vector3(0f,0f,image.transform.localScale.z);
                        finish_color = true;
                        shadow_light.SetActive(true);
                    }
                    else{
                        image.transform.localScale -= new Vector3(0f,0f,speed);
                        image.transform.position += new Vector3(0f,5f*speed/2,0f);
                    }
                }
            }
        }
    }

}
