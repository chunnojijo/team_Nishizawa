using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEvent : MonoBehaviour {

	// Use this for initialization
	ParticleSystem particle;
	void Start () {
		particle= this.GetComponentInChildren<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other){
		
			Debug.LogWarning("Particle Enter");
		if(other.transform.tag=="PlayerHand"){
			particle.Play();
			Debug.LogWarning("Particle");

		}
	}
	private void OnTriggerExit(Collider other){
		if(other.transform.tag=="PlayerHand"){
			particle.Stop();

		}
	}
}
