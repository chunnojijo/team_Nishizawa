using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceEvent : MonoBehaviour {

    [SerializeField]private Navi navi;

    [SerializeField] private GameObject LightForDebugForAnimation;
    [SerializeField] private GameObject Light;
    [SerializeField] private GameObject[] pos;

    private GameObject player;

    [SerializeField] AudioClip DoorClose;
    private AudioSource DoorCloseSource;
    [SerializeField] AudioClip DoorLock;
    private AudioSource DoorLockSource;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("LocalAvatar");
        DoorLockSource.clip = DoorLock;
        DoorCloseSource.clip = DoorClose;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {

        }
    }

    public IEnumerator EntranceEvent1()
    {
        yield return new WaitForSeconds(3f);

        DoorCloseSource.Play();

        yield return new WaitForSeconds(1.5f);

        DoorLockSource.Play();

        yield return new WaitForSeconds(1f);

        navi.Comeback();

        yield return new WaitForSeconds(0.5f);

        navi.Say("扉が閉まっちゃった!");

        yield return new WaitForSeconds(1f);

        LightForDebugForAnimation.GetComponent<Animator>().SetTrigger("LightEvent");

        yield return new WaitForSeconds(4.1f);

        navi.Say("うわっ！いきなり暗くなったね..");

        yield return new WaitForSeconds(1f);

        navi.Say("それじゃあ...");

        yield return new WaitForSeconds(1f);

        navi.Say("はい!どうぞ");

        yield return new WaitForSeconds(0.5f);

        Light.SetActive(true);

        yield return new WaitForSeconds(1f);

        navi.Say("これで暗いところも怖くないね!");

        yield return new WaitForSeconds(1f);

        navi.Say("こっちに進んでみようよ");

        navi.GoTo(pos[0].transform.position);

        while ((pos[0].transform.position - player.transform.position).magnitude > 1.5)
        {
            yield return null;
        }
        navi.Comeback();

        while ((pos[1].transform.position - player.transform.position).magnitude > 1)
        {
            yield return null;
        }

        navi.

        yield break;
    }
}
