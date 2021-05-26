using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarRight : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
      rb = this.GetComponent<Rigidbody>();
      rb.velocity = new Vector3(Random.Range(-10f, -16f),  0f, 0f); //set car with random speed
    }

    // Update is called once per frame
    void Update()
    {
      if(transform.position.x < -40){ //if car off screen
        Destroy(this.gameObject); //Destroy
      }
    }

}
