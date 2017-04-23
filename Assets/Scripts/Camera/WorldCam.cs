using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCam : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, -15f + Mathf.PingPong(Time.time * 3, 1));
    }
}
