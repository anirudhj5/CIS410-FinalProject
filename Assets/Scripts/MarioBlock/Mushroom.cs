using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gameLogic
{
  public class Mushroom : MonoBehaviour
  {
      private int direction = 0;
      public bool velFlag = true;
      Vector3 temp;
      private Rigidbody rb;
      void Start()
      {

        direction = Random.Range(1, 3);
        //random direction
        if( direction > 1)
        {
          direction = -1;
        }
        rb = this.GetComponent<Rigidbody>();

        rb.velocity = new Vector3(((direction * 8f) * StartGame.gameSpeed),  0f, 0f); //set mushroom with speed
      }

      // Update is called once per frame
      void Update()
      {

        if (StartGame.gameSpeed == 2 && velFlag && rb.velocity.y < -2 ) //makes it drop faster in hardmdoe
        {
          rb.velocity = new Vector3((direction * 8f) * StartGame.gameSpeed,  (rb.velocity.y - 10), 0f);
          velFlag = false;
        }

        rb.velocity = new Vector3((direction * 8f) * StartGame.gameSpeed, rb.velocity.y, 0f); //update position


        if(rb.transform.position.x < -37) //if off left side screen put on right side
        {
          temp = new Vector3(74.0f,0f,0f);
          rb.transform.position += temp;
        }
        else if (rb.transform.position.x > 37) //if off right side screen put on temp side
        {
          temp = new Vector3(-74.0f,0f,0f);
          rb.transform.position += temp;
        }
      }
  }
}
