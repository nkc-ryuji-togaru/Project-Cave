using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleMove : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
        float side = Input.GetAxis("Horizontal") * 1.0f;
        float front = Input.GetAxis("Vertical") * 0.1f;
        transform.Translate(Vector3.forward * front);
        transform.Rotate(0,side,0);
	}
}
