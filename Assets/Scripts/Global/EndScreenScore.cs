using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace gameLogic{
  public class EndScreenScore : MonoBehaviour
  {
      public TextMeshProUGUI scoreText;
      void Start()
      {
        scoreText.text =  "" + (StartGame.score); //set score in UI
      }

  }
}
