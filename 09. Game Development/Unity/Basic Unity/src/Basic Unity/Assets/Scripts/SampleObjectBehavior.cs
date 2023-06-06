using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SampleObjectBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 delta = new Vector3(1.0f, 1.0f, 1.0f);

        transform.Translate(delta);
    }

    // Update is called once per frame
    void Update()
    {
        MovePosition();
        //VectorMotion();

    }
    Vector3 target = new Vector3(8, 3, 0);
    Vector3 origin = new Vector3(0, 3, 0);
    private void VectorMotion()
    {

        //1. MoveTowards
        //transform.position = Vector3.MoveTowards(transform.position, target, 0.01f);

        Vector3 velo = Vector3.zero;
        //2. SmoothDamp
        //transform.position = Vector3.SmoothDamp(transform.position, target, ref velo, 0.1f);

        //3. Lerp
        //transform.position = Vector3.Lerp(transform.position, target, 0.05f);

        //4. S Lerp
        // if (Input.GetKeyDown(KeyCode.Return))
        //     transform.position = Vector3.Slerp(transform.position, target, 0.5f);

        // if (Input.GetKeyDown(KeyCode.UpArrow))
        //     transform.position = Vector3.Lerp(transform.position, origin, 0.5f);

        if (Input.GetKey(KeyCode.Return))
            transform.position = Vector3.Slerp(transform.position, target, 1f * Time.deltaTime);

        if (Input.GetKey(KeyCode.UpArrow))
            transform.position = Vector3.Slerp(transform.position, origin, 1f * Time.deltaTime);
    }

    void MovePosition()
    {
        Vector3 vec = new Vector3(Input.GetAxis("Horizontal") * 10 * Time.deltaTime, Input.GetAxis("Vertical") * 10 * Time.deltaTime, 0);
        transform.Translate(vec);

        // if (Input.anyKeyDown)
        // {
        //     Vector3 position = new Vector3();

        //     if (Input.GetKeyDown(KeyCode.UpArrow))
        //         position = new Vector3(-1.0f, 0f, -1.0f);
        //     if (Input.GetKeyDown(KeyCode.DownArrow))
        //         position = new Vector3(1.0f, 0f, 1.0f);
        //     if (Input.GetKeyDown(KeyCode.LeftArrow))
        //         position = new Vector3(1.0f, 0f, -1.0f);
        //     if (Input.GetKeyDown(KeyCode.RightArrow))
        //         position = new Vector3(-1.0f, 0f, 1.0f);

        //     transform.Translate(position);
        // }
    }
}
