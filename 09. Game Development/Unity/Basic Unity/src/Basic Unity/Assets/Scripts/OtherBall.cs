using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherBall : MonoBehaviour
{
    MeshRenderer mesh;
    Material material;
    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        material = mesh.material;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "My Ball")
            material.color = Color.black;
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.name == "My Ball")
            material.color = Color.white;
    }

    void OnCollisionStay(Collision collision)
    {

    }
}
