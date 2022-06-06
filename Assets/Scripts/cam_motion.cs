using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam_motion : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = .5f;

    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hInput = Input.GetAxisRaw("Horizontal");
        Vector3 loc = new Vector3(hInput*speed, 0, 0);
        transform.position += loc;
    }
}
