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
      RandomSceneLoader RandomSceneLoader;
      int countGames;

      void Start()
      {
          flag = true;
          time = 11;
          timeText.text =  "" + ((int)time); //set time in UI
          RandomSceneLoader = gameObject.AddComponent<RandomSceneLoader>();
          countGames = SceneManager.sceneCountInBuildSettings -1;
      }

      void FixedUpdate()
      {
          time -= Time.deltaTime;
          timeText.text = "" + ((int)time); //update time in UI
          if (time < 0f)
          { //if time less than zero load new scene
            if (flag)
            {
              flag = false;
              RandomSceneLoader.LoadRandomScene();
            }
          }
      }
  }
}
