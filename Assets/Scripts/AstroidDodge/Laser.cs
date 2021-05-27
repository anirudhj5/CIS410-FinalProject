using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gameLogic
{
  public class Laser : MonoBehaviour
  {
      private Rigidbody rb;
      void Start()
      {
        rb = this.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0f,  (13f*StartGame.gameSpeed), 0f); //set lazer with speed
      }

      private void OnTriggerEnter(Collider other)
      {
        if(other.gameObject.name == "Asteroid(Clone)") //if hits Asteroid
        {
          this.gameObject.SetActive(false); //delete lazer
        }
      }
  }
}
