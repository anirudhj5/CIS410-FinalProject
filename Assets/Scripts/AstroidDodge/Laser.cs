using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private Rigidbody rb;
    void Start()
    {
      rb = this.GetComponent<Rigidbody>();
      rb.velocity = new Vector3(0f,  13f, 0f); //set lazer with speed
    }

    private void OnTriggerEnter(Collider other)
    {
      if(other.gameObject.name == "Asteroid(Clone)")
      {
        this.gameObject.SetActive(false);
      }
    }
}
