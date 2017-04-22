using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    Vector3 offset;
    float rate = 5f;

	void Start () {
        offset = transform.position - player.transform.position;
        Debug.Log(offset);
    }
	
	void LateUpdate () {

        transform.up = player.transform.up;

        Vector3 desiredPos = player.transform.position + offset;
        Vector3 pos = Vector3.Lerp(transform.position, desiredPos, rate * Time.deltaTime);
        //transform.position = desiredPos;
        transform.position = pos;
        transform.LookAt(player.transform);
        transform.Rotate(Vector3.forward, player.transform.rotation.eulerAngles.z);

        //transform.Rotate(Vector3.right, -hero.transform.rotation.eulerAngles.x);
    }
}
