using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour {

    public float walkSpeed = 15f;
    public float jumpForce = 300f;

    public LayerMask groundedMask;

    Rigidbody rigid;

    Transform cameraT;
    float verticalLookRotation;

    Vector3 moveAmount;
    Vector3 smoothMoveVelocity;

    bool grounded;

    void Start () {
        //cameraT = Camera.main.transform;
        rigid = GetComponent<Rigidbody>();
    }
	
	void Update () {
        //transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivityX);
        //verticalLookRotation += Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivityY;
        //verticalLookRotation = Mathf.Clamp(verticalLookRotation, -60f, 60f);
        //cameraT.localEulerAngles = Vector3.left * verticalLookRotation;

        Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        Vector3 targetMoveAmount = moveDir * walkSpeed;
        moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, 0.15f);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                rigid.AddForce(transform.up * jumpForce);
            }
        }

        grounded = false;
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1.5f, groundedMask))
        {
            grounded = true;
        }
	}

    void FixedUpdate ()
    {
        rigid.MovePosition(rigid.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
    }
}
