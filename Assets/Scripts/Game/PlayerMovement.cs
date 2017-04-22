using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    float speed = 1.0f;
    float gravity = 9.98f;
    public Transform gravitySource;

    Vector3 gravityVector;

	void Start () {
        gravityVector = (gravitySource.position - transform.position).normalized;
    }
	
	void Update () {
        gravityVector = (gravitySource.position - transform.position).normalized * gravity;

        transform.position += gravityVector * Time.deltaTime;

        transform.rotation = Quaternion.LookRotation(-gravityVector);

        //GetComponent<Rigidbody>().AddForce(gravityVector * Time.deltaTime, ForceMode.Acceleration);
    }

    void OnTriggerStay (Collider other)
    {
        transform.position = gravitySource.position - (gravityVector.normalized * other.transform.localScale.y * 0.5f);
    }

    void OnCollisionStay (Collision col)
    {
        /*
        if (col.collider == gravitySource.GetComponent<Collider>())
        {
            transform.position = gravitySource.position - gravityVector.normalized * (gravitySource.localScale.x / 2.0f);
        }
        */
    }
}
