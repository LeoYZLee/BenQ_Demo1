using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate_bottle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject pivot; //The point we want to rotate around
        pivot = gameObject;
        float speed = -20; //Speed of the rotation
        Vector3 direction = pivot.transform.up; //rotation direction

        gameObject.transform.RotateAround(
            pivot.transform.position,
            direction,
            speed * Time.deltaTime
        );

    }
}
