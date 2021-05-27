using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomColider : MonoBehaviour
{
    public GameObject Mushroom;
    private void OnTriggerEnter(Collider other)
    {
      if (other.gameObject.name == "Mario") //disapear when mario hits it
      {
        Mushroom.SetActive(false);
      }
    }
}
