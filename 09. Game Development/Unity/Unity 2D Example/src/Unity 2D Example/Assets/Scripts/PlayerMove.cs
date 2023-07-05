using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float maxSpeed = 3f;

    Rigidbody2D body;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        body.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (body.velocity.x > maxSpeed)
        {
            body.velocity = new Vector2(maxSpeed, body.velocity.y);
        }
        else if (body.velocity.x < -maxSpeed)
        {
            body.velocity = new Vector2(-maxSpeed, body.velocity.y);
        }
    }
}
