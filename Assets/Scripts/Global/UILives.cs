using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gameLogic{
  public class UILives : MonoBehaviour
  {
      public GameObject heart2;
      public GameObject heart3;
      void Start(){

      }

      void Update()
      {
        //Debug.Log(StartGame.lives);
        if( StartGame.lives < 3) //if lives < 3
        {
          heart3.SetActive(false); //hide third heart container
        }

        if(StartGame.lives < 2)
        {
          heart2.SetActive(false);
        }

        //dont need to hide first game ends before
      }
  }
}
