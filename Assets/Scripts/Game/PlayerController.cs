using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed = 5f;
    Vector3 moveDirection;
    Rigidbody rigid;

    void Start ()
    {
        rigid = GetComponent<Rigidbody>();
    }

	void Update () {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
	}

    void FixedUpdate ()
    {
        rigid.MovePosition(rigid.position + transform.TransformDirection(moveDirection) * moveSpeed * Time.fixedDeltaTime);
    }
}
