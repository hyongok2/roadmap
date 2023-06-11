using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCan : MonoBehaviour
{

    public float rotateSpeed; 
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime,Space.World );
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name =="Player")
        {
            var player = other.GetComponent<PlayerBall>();
            player.itemCount++;
            gameObject.SetActive(false);
        }
    }
}
