using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gameLogic
{
  public class Asteroid : MonoBehaviour
  {
      public float speed = 25.0f * StartGame.gameSpeed; //Asteroid speed
      private Rigidbody rb;
      public Animator animator;

      void Start()
      {
        rb = this.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0f,  Random.Range(-speed, -(speed+10f)), 0f); //add random velocity to asteroid

        rb.transform.Rotate(new Vector3(0f, 0f, Random.Range(-360f, 360f))); //rotate asteroid randomly
        rb.transform.localScale *= Random.Range(.25f, .5f); //random size of asteroid

      }

      void Update()
      {
        if(transform.position.y < -10) //if off screen
        {
          Destroy(this.gameObject); //Destroy
        }
      }

      private void OnTriggerEnter(Collider other)
      {
        if(other.gameObject.name == "Laser(Clone)")
        {
          rb.velocity = new Vector3(0f,  0f, 0f); //stop moving
          SetAllCollidersStatus(false); //turn off all colliders
          animator.SetTrigger("RockExplode"); //trigger explode animation
          StartCoroutine(Wait()); //end game

        }
      }

      public void SetAllCollidersStatus (bool active) {
        foreach(Collider c in GetComponents<Collider> ()) {
          c.enabled = active;
        }
      }

      IEnumerator Wait()
      {
        yield return new WaitForSeconds((.8f)); //wait for animation
        this.gameObject.SetActive(false); //delete asteroid
      }
  }
}
