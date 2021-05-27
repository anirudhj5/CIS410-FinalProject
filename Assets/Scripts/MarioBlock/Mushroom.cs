using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    int direction = 0;
    Vector3 temp;
    private Rigidbody rb;
    void Start()
    {
      direction = Random.Range(1, 3);
      if( direction > 1)
      {
        direction = -1;
      }
      rb = this.GetComponent<Rigidbody>();

      rb.velocity = new Vector3((direction * 8f),  0f, 0f); //set mushroom with speed
    }

    // Update is called once per frame
    void Update()
    {
      rb.velocity = new Vector3((direction * 8f),  rb.velocity.y, 0f);

      if(rb.transform.position.x < -37)
      {
        temp = new Vector3(74.0f,0f,0f);
        rb.transform.position += temp;
      }
      else if (rb.transform.position.x > 37){
        temp = new Vector3(-74.0f,0f,0f);
        rb.transform.position += temp;
      }
    }
}
