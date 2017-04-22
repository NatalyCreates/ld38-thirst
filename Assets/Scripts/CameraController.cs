using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject hero;
    Vector3 offset;
    float rate = 5f;

	void Start () {
        offset = transform.position - hero.transform.position;
    }
	
	void LateUpdate () {

        transform.up = hero.transform.up;
        //hero.transform.forward = transform.forward;

        Vector3 desiredPos = hero.transform.position + offset;
        //Vector3 pos = Vector3.Lerp(transform.position, desiredPos, rate * Time.deltaTime);
        transform.position = desiredPos;
        transform.LookAt(hero.transform);
        transform.Rotate(Vector3.forward, hero.transform.rotation.eulerAngles.z);
        //transform.Rotate(Vector3.right, -hero.transform.rotation.eulerAngles.x);
    }
}
