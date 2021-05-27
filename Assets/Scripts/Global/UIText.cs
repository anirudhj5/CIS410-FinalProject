using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace gameLogic{
  public class UIText : MonoBehaviour
  {
      private float time;
      bool flag;
      public TextMeshProUGUI timeText;
      public TextMeshProUGUI scoreText;
      bool gameRunning = true;
      RandomSceneLoader RandomSceneLoader;
      int countGames;

      void Start()
      {
          flag = true;
          time = 11/StartGame.gameSpeed; //5 seconds if hard mode 10 on easy
          timeText.text =  "" + ((int)time); //set time in UI
          scoreText.text =  "" + (StartGame.score); //set score in UI
          RandomSceneLoader = gameObject.AddComponent<RandomSceneLoader>();
          countGames = SceneManager.sceneCountInBuildSettings -1;
          StartCoroutine(Score()); //adds score every seconds
      }

      void FixedUpdate()
      {
          time -= Time.deltaTime;
          timeText.text = "" + ((int)time); //update time in UI
          if (time < 0f) //if time less than zero load new scene
          {
            if (flag)
            {
              flag = false;
              gameRunning = false;
              RandomSceneLoader.LoadRandomScene();

            }
          }
      }

      IEnumerator Score()
      {
        while(gameRunning)
        {
          yield return new WaitForSeconds(1);
          StartGame.score += 1000*StartGame.gameSpeed; //1000 per second on easy 2000 on hard
          scoreText.text =  "" + (StartGame.score); //update score in UI
        }

      }
  }
}
