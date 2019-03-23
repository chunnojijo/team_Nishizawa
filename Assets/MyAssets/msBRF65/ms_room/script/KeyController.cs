using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour {
    public GameObject ms_roomManegar,player,key,ms_light;
    ms_roomManegar ms_room;
    ms_LightController ms_light_c;
    public float key_player_direction = 2.0f,forcerate_to_key = 0.2f, key_pos_z = 1.23f;
    bool finish_key_animation = false;

	// Use this for initialization
	void Start () {
        ms_room = ms_roomManegar.GetComponent<ms_roomManegar>();
        ms_light_c = ms_light.GetComponent<ms_LightController>();
        key.GetComponent<Rigidbody>().useGravity = false;
        key.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(Vector3.Distance(player.transform.position, this.transform.position));
        if(ms_room.finish == true && !finish_key_animation && Vector3.Distance(player.transform.position , this.transform.position) < key_player_direction && ms_light_c.finish_color)
        {
            key.gameObject.SetActive(true);
            finish_key_animation = true;
            fall_key();
        }
        if (key.transform.position.z <= key_pos_z)
        {
            key.GetComponent<Rigidbody>().isKinematic = true;
        }
	}

    void fall_key()
    {
        ms_room.donuts.SetActive(false);
        ms_room.cookies.SetActive(false);
        key.GetComponent<Rigidbody>().AddForce(new Vector3(-1f,3f,0f) * forcerate_to_key);
    }
}
