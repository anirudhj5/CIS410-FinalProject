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
        scoreText.text =  "" + (StartGame.score.ToString().PadLeft(6, '0')); //set score in UI
      }

  }
}
