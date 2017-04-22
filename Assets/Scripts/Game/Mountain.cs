using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mountain : MonoBehaviour {

    GravityAttractor attractor;
    Transform myTransform;

    void Start () {
        attractor = GameObject.FindGameObjectWithTag("earth").GetComponent<GravityAttractor>();

        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        GetComponent<Rigidbody>().useGravity = false;
        myTransform = transform;

        Color[] colors = new Color[3];
        colors[0] = new Color(161f / 255f, 106f / 255f, 60f / 255f);
        colors[1] = new Color(127f / 255f, 74f / 255f, 28f / 255f);
        colors[2] = new Color(85f / 255f, 42f / 255f, 5f / 255f);

        gameObject.GetComponent<Renderer>().material.color = colors[Random.Range(0,3)];
	}
	
	void FixedUpdate () {
        attractor.Attract(myTransform);
	}
}
