using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class LightController : MonoBehaviour {
    private Subject<int> colorSubject = new Subject<int>();

    public IObservable<int> OnTimeChanged
    {
        get { return colorSubject; }
    } 

    // Use this for initialization
    void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator TimerCoroutine()
    {
        var time = 100;
        while (time > 0)
        {
            time--;

            //timerSubject.OnNext(time);
        }
        yield return new WaitForSeconds(1);
    }
}
