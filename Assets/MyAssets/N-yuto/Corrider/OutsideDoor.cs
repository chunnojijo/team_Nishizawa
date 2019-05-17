using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OutsideDoor : MonoBehaviour
{
     Animation UnLockAnim;
    [SerializeField]AudioSource[] audioSources;

    [SerializeField] private GameObject FakeKey;

    [SerializeField] UnityEvent DoorOpenEvent;


    /*
    [SerializeField] GameObject StartPos;
    [SerializeField] GameObject EndPos;
    */

    void Start()
    {
        FakeKey.SetActive(false);
        UnLockAnim = GetComponent<Animation>();

    }

    // Update is called once per frame
/*
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.K) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            StartCoroutine(Unlock());
        }


    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Key")
        {
            GrabRelease.ReleaseAllObjects();
            StartCoroutine(Unlock());
            other.gameObject.SetActive(false);
        }
    }

    IEnumerator Unlock()
    {
        UnLockAnim.Play();

        yield return new WaitForSeconds(0.25f);

        audioSources[0].Play();

        yield return new WaitForSeconds(1.1f);

        audioSources[1].Play();

        yield return new WaitForSeconds(1f);

        DoorOpenEvent.Invoke();

        yield return null;

        audioSources[2].Play();


        /*
        FakeKey.transform.position = StartPos.transform.position;
        FakeKey.transform.rotation = StartPos.transform.rotation;

        iTween.MoveTo(FakeKey, EndPos.transform.position, 1f);

        yield return new WaitForSeconds(0.4f);

        float StartYAngle = StartPos.transform.eulerAngles.y;
        float EndYangle = EndPos.transform.eulerAngles.y;

        yield return new WaitForSeconds(0.4f);

        float XAngle = EndPos.transform.eulerAngles.x;
        float ZAngle = EndPos.transform.eulerAngles.z;

        yield return new WaitForSeconds(0.4f);


        float t = 0f;
        float YAngle;

        while (t <= 1f)
        {
            t += Time.deltaTime;
            YAngle = Mathf.Lerp(StartYAngle, EndYangle, t);

            FakeKey.transform.eulerAngles = new Vector3(XAngle, YAngle, ZAngle);

            yield return null;
        }
        */

        yield break;
    }

}
