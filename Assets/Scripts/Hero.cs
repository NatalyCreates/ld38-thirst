using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour {

    GameObject earth;

    void Start () {
        earth = GameObject.FindGameObjectWithTag("earth");
    }
	
	void FixedUpdate ()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit))
        {
            transform.up = hit.normal;
        }

    }

    void Update () {

        //Vector3 speed = new Vector3(Input.GetAxis("Horizontal") * 4f * Time.deltaTime, 0f, Input.GetAxis("Vertical") * 4f * Time.deltaTime);

        //transform.Translate(speed);

        //Vector3 dir = (transform.position - earth.transform.position).normalized;

        //gameObject.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0f, -10f, 0f), ForceMode.Force);
        //gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * -10f, ForceMode.Force);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void Jump ()
    {
        //gameObject.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0f, 2f, 0f), ForceMode.Impulse);
    }
}
