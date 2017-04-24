using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBody : MonoBehaviour {

    GravityAttractor attractor;
    Transform myTransform;

    void Start () {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        GetComponent<Rigidbody>().useGravity = false;
        myTransform = transform;
        attractor = GameObject.FindGameObjectWithTag("earth").GetComponent<GravityAttractor>();
    }
	
	void FixedUpdate () {
        
        if (tag == "platform")
        {
            float h = GetComponent<Platform>().height;
            attractor.Attract(myTransform, 20 + h);
        }
        else
        {
            attractor.Attract(myTransform);
        }
    }
}
