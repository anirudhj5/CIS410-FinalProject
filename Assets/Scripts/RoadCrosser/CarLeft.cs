using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gameLogic
{
  public class CarLeft : MonoBehaviour
  {
    private Rigidbody rb;
    public float speed;

    void Start()
    {
      speed = 10 * StartGame.gameSpeed;
      rb = this.GetComponent<Rigidbody>();
      rb.velocity = new Vector3(Random.Range(speed, (speed+6)),  0f, 0f); //set car with random speed
    }

    void Update()
    {
      if(transform.position.x > 40 ){ //if car offscreen
        Destroy(this.gameObject); //Destroy
      }
    }
  }
}
