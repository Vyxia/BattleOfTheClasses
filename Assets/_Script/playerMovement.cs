using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

    private float f_walkSpeed = 5f;
    private bool isSprinting = false;
    private GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
	}
}
