using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class chub_motion : MonoBehaviour
{
    public float speed;
    public float jumpForce = 2.0f;
    public float gravityForce = 0.2f;

    private Vector3 jump;
    private Vector3 gravity;
    private bool isGrounded;
    private GameObject main_cam;



    private Vector3 respawnloc;
    private Vector3 respawnlocforcam;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        gravity = new Vector3(0.0f, -1.0f, 0.0f);
        respawnloc = new Vector3(-5f, 7f, 5f);
        main_cam = GameObject.Find("Main Camera");

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "floor") isGrounded = true;
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
            respawnlocforcam = main_cam.GetComponent<Transform>().position;
            respawnlocforcam.x = respawnloc.x;
            main_cam.GetComponent<Transform>().position = respawnlocforcam;

        }

        //movement
        float hInput = Input.GetAxisRaw("Horizontal");
        float vInput = Input.GetAxisRaw("Vertical");
        Vector3 mov = new Vector3(hInput, 0, vInput);
        transform.position += mov * speed;

        if (Input.GetKey("space") && isGrounded){
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
}
