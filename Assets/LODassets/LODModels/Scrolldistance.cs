using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Scrolldistance : MonoBehaviour {
    //public Slider slider;
    public Scrollbar slider;
    float value = 0f;
    public float valueMultiplier;
    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        value = slider.value;
        Vector3 temp = new Vector3(0f, 0f, value * valueMultiplier);
        transform.position = temp;
	}
}
