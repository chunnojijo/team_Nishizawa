using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMove : MonoBehaviour {

    //[SerializeField] Vector3 StartPos;
    //[SerializeField] float time = 1f;
    [SerializeField] string PathName;
    [SerializeField] int PathCount;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    IEnumerator MoveRepeat()
    {

        while (true)
        {

            GoAlongPath();
            yield return new WaitForSeconds(PathCount*2+1);

            //ReturnToStart();
            //yield return new WaitForSeconds(time);

        }

    }

    public void StartLightMove()
    {
        StartCoroutine(MoveRepeat());
    }

    void GoAlongPath()
    {
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath(PathName),
       "time", PathCount*2+1, "easeType", iTween.EaseType.linear, "orienttopath", false));
    }

    void ReturnToStart()
    {
       // iTween.MoveTo(gameObject, StartPos, time);
    }
}
