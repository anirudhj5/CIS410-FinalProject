using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;
using static gameLogic.randomSceneLoader;

namespace gameLogic
{
  public class PlayerCollisionAsteroid : MonoBehaviour
  {
    private int flag = 0; //collider triggers twice at start
    private int oneFlag = 1;
    public GameObject instrText;
    randomSceneLoader randomSceneLoader;

    void Awake()
    {
      randomSceneLoader = gameObject.AddComponent<randomSceneLoader>();
      startGame.lifeFlag = 0;
    }

    void Update()
    {
      if(Keyboard.current.aKey.wasPressedThisFrame || Keyboard.current.dKey.wasPressedThisFrame) //if a or d is pressed
      {
        StartCoroutine(HideText()); //hide instructions
      }
    }

    private void OnTriggerEnter(Collider other)
    {
      if (flag > 1){ //collides twice on start
        if(oneFlag == 1){
        startGame.lifeFlag = 1;
        randomSceneLoader.LoadRandomScene();
        oneFlag = 0;
        }
      }
      flag++; //collides twice on start
    }

    IEnumerator HideText()
    {
      yield return new WaitForSeconds(1.5f);
      instrText.SetActive(false);
    }
  }
}
