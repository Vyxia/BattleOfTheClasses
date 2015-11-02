using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public GameObject world;

    Rigidbody2D rig;
    Vector3 horizontal;
    Vector3 vertical;

    // Use this for initialization
    void Start () {
        rig = gameObject.GetComponent<Rigidbody2D>();

        Time.timeScale = 10;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        
        horizontal = transform.right * Input.GetAxis("Horizontal");
        vertical = transform.up * Input.GetAxis("Vertical");

        rig.AddForce ((horizontal + vertical) * Time.deltaTime * 1000);

	}
}
