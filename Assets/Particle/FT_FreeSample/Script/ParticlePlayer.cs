using UnityEngine;
using System.Collections;

public class ParticlePlayer : MonoBehaviour {

	private ParticleSystem PS;
	
	void Start () {
		PS = GetComponent<ParticleSystem> ();
	}

	public void playPS(){
		PS.Play ();
	}
}