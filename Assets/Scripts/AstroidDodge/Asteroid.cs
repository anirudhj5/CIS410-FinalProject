using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed = 25.0f; //Asteroid speed
    private Rigidbody rb;
    public Animator animator;

    void Start()
    {
      rb = this.GetComponent<Rigidbody>();
      rb.velocity = new Vector3(0f,  Random.Range(-25f, -45f), 0f); //add random velocity to asteroid

      rb.transform.Rotate(new Vector3(0f, 0f, Random.Range(-360f, 360f))); //rotate asteroid randomly
      rb.transform.localScale *= Random.Range(.7f, 1f); //random size of asteroid

    }

    void Update()
    {
      if(transform.position.y < -10)
      { //if off screen
        Destroy(this.gameObject); //Destroy
      }
    }

    private void OnTriggerEnter(Collider other)
    {
      if(other.gameObject.name == "Laser(Clone)")
      {
        rb.velocity = new Vector3(0f,  0f, 0f);
        SetAllCollidersStatus(false);
        animator.SetTrigger("RockExplode");
        StartCoroutine(Wait());

      }
    }

    public void SetAllCollidersStatus (bool active) {
      foreach(Collider c in GetComponents<Collider> ()) {
        c.enabled = active;
      }
    }

    IEnumerator Wait()
    {
      yield return new WaitForSeconds(.8f);
      this.gameObject.SetActive(false);
    }
}
