using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBall : MonoBehaviour
{
    Rigidbody rigid;



    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        //rigid.velocity = new Vector3(2, 4, 3); //한번만 속도가 부여됨.
        //rigid.AddForce(Vector3.up * 5, ForceMode.Impulse);
    }

    // Update is called once per frame
    void FixedUpdate() //rigidbody제어는 fixed Update에서 해야 한다고 함.
    {
        //1. 속력 바꾸기
        //rigid.velocity = new Vector3(2, 4, 3);  // 속도가 유지됨.

        //2. 힘 가하기
        // if (Input.GetButton("Jump"))
        // {
        //     rigid.AddForce(Vector3.up * 5, ForceMode.Impulse);
        // }

        Vector3 vec = new Vector3(
            Input.GetAxisRaw("Horizontal") * 0.1f,
            0,
            Input.GetAxisRaw("Vertical") * 0.1f
            );

        rigid.AddForce(vec, ForceMode.Impulse);

        //3. 회전력 주기
        //rigid.AddTorque(Vector3.up);//vec는 축방향


    }

    private bool isGround = true;
    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Cube" && isGround == true)
        {
            rigid.AddForce(Vector3.up * 2f, ForceMode.Impulse);
        }

    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.collider.name == "Ground")
        {
            isGround = true;
        }

    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.name == "Ground")
        {
            isGround = false;
        }
    }
}
