﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravityAttractor : MonoBehaviour {

    public float gravity = -10f;

    public GameObject dbgTxt;

	public void Attract (Transform body, float setHeight = 0f) {
        Vector3 gravityUp = (body.position - transform.position).normalized;
        Vector3 bodyUp = body.up;

        /*
        if (body.gameObject.name == "Platform")
        {
            string dbg = "Distance from Planet for object " + body.gameObject.name + " is " + Vector3.Distance(body.position, transform.position);
            Debug.Log(dbg);
            dbgTxt.GetComponent<Text>().text = dbg;
        }*/

        //Debug.Log("Dist is: " + Vector3.Distance(body.position, transform.position));
        if (Vector3.Distance(body.position, transform.position) > setHeight)
        {
            body.GetComponent<Rigidbody>().AddForce(gravityUp * gravity);
        }
        else
        {
            body.GetComponent<Rigidbody>().velocity = Vector3.zero;
            body.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            body.GetComponent<Rigidbody>().isKinematic = true;
        }

        //Quaternion targetRotation = Quaternion.FromToRotation(bodyUp, gravityUp) * body.rotation;
        //body.rotation = Quaternion.Slerp(body.rotation, targetRotation, 0.4f);
        //body.rotation = targetRotation;
        body.LookAt(transform);
        body.Rotate(-90f, 0f, 0f);
        body.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
    }
}
