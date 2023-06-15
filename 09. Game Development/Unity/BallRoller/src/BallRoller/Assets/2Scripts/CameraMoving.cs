using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    Transform playerTransform;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        offset = transform.position - playerTransform.position;
    }

    // 카메라는 Late Update를 사용하는게 일반적이다.
    void LateUpdate()
    {
        transform.position = playerTransform.position + offset;
    }

}
