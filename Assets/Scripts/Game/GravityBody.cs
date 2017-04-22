using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBody : MonoBehaviour {

    public GravityAttractor attractor;
    Transform myTransform;

    void Start () {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        GetComponent<Rigidbody>().useGravity = false;
        myTransform = transform;
    }
	
	void FixedUpdate () {
        attractor.Attract(myTransform);
	}
}
