using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public TMP_Text StopWatchDisplay;
    private Rigidbody rb;

    public float ForwardForce;
    public float SideForce;
    public float jumpForce;

    private bool offGround = false;

    private bool timerActive = false;

    public int energyLevel;

    private bool gameOver = false;
    private TimeSpan stopwatchTime;
    private float timeTrack = 0;

    // Start is called before the first frame update    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y <= -10 && gameOver == false)
        {
            Debug.Log("Game Over");
            gameOver = true;
            return;
        }
        if (timerActive)
        {
            timeTrack = timeTrack + Time.deltaTime;
            stopwatchTime = TimeSpan.FromSeconds(timeTrack);
            StopWatchDisplay.text = stopwatchTime.ToString(@"mm\:ss\:fff");
        }
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

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            energyLevel--;
            if (energyLevel == 0)
            {
                Debug.Log("Game Over");
                gameOver = true;
                return;
            }
            Debug.Log(energyLevel);
        }

    }

    void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.collider.name == "Ground")
        {
            offGround = false;
        }
    }

    void OnTriggerEnter(Collider collier)
    {
        if (collier.name == "Start")
        {
            timerActive = true;
            Debug.Log("Stopwatch activated!");
        }

        if (collier.name == "End")
        {
            timerActive = false;
            Debug.Log("Stopwatch deactivated!");
        }
    }

}
