using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    public float ForwardForce;
    public float SideForce;
    public float jumpForce;

    private bool offGround = false;

    // Start is called before the first frame update    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 0, ForwardForce * Time.deltaTime);
        }

        if (Input.GetKey("z"))
        {
            rb.AddForce(0, 0, -ForwardForce * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            rb.AddForce(SideForce * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-SideForce * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("j") && offGround == false)
        {
            offGround = true;
            rb.velocity = Vector3.up * jumpForce;
        }

    }

    void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.collider.name == "Ground")
        {
            offGround = false;
        }
    }

}