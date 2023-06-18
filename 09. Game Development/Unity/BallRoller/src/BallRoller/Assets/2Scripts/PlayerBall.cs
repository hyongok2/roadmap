using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerBall : MonoBehaviour
{
    public float jumpPower = 10;
    bool isJump;
    Rigidbody body;
    public int itemCount;
    public GameManager manager;
    AudioSource audio;


    private void Awake()
    {
        isJump = false;
        body = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Jump") && isJump == false)
        {
            isJump = true;
            body.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        body.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isJump = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            itemCount++;
            audio.Play();
            manager.playerItemText.text = itemCount.ToString();
            other.gameObject.SetActive(false);
        }
        else if (other.tag == "Finish")
        {
            if(itemCount == manager.totalItemCount)
            {
                manager.stage++;
            }

            if (manager.stage == 3) manager.stage = 0;


            SceneManager.LoadScene(manager.stage);

        }
    }

}
