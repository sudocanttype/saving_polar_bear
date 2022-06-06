using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class chub_motion : MonoBehaviour
{
    public float speed = .5f;
    public float turnSmoothTime = 0.1f;
    public float jumpForce = 2.0f;
    public float gravityForce = 0.2f;

    public Transform cam;

    float turnV;
    private Vector3 jump;
    private Vector3 gravity;
    private bool isGrounded;
    private GameObject main_cam;



    private Vector3 respawnloc;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        gravity = new Vector3(0.0f, -1.0f, 0.0f);
        respawnloc = new Vector3(-5f, 7f, 5f);

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "floor") isGrounded = true;
    }

    private void OnTriggerEnter(Collider other)
    {
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //make him fall
        rb.AddForce(gravity * gravityForce, ForceMode.Impulse);

        //death and respawn
        if (transform.position.y < -5){
            //on death move char and cam
            transform.position = respawnloc;
        }

        //movement
        float hInput = Input.GetAxisRaw("Horizontal");
        float vInput = Input.GetAxisRaw("Vertical");
        //basic wasd up down, use normalized so no speedup when 2 buttons pressed
        Vector3 mov = new Vector3(hInput, 0, vInput).normalized;

        if(mov.magnitude >= .1f){
            float ang = Mathf.Atan2(mov.x, mov.y) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float ang2 = Mathf.SmoothDampAngle(transform.eulerAngles.y, ang, ref turnV, turnSmoothTime);
            //idk some math
            transform.rotation = Quaternion.Euler(0f, ang2, 0f);

            Vector3 dir = Quaternion.Euler(0f, ang, 0f) * Vector3.forward;
            transform.position += dir.normalized * speed * Time.deltaTime;
        }

        if (Input.GetKey("space") && isGrounded){
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
}
