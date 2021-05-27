using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;
using gameLogic;

namespace gameLogic{
  public class PlayerCollisionTurtle : MonoBehaviour

  {
    public GameObject instrText;
    private int flag = 0; //collides twice on start
    private int oneFlag = 1;
    RandomSceneLoader RandomSceneLoader;

    void Awake()
    {
      StartGame.lifeFlag = 1; //if time runs out lose a life
      RandomSceneLoader = gameObject.AddComponent<RandomSceneLoader>();
    }

    void Update()
    {
      if(Keyboard.current.wKey.wasPressedThisFrame || Keyboard.current.aKey.wasPressedThisFrame){ //if w or a pressed
        StartCoroutine(HideText());
      }
    }

    IEnumerator HideText()
    {
      yield return new WaitForSeconds(1.5f);
      instrText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
      if (flag > 1){ //collides twice on start
        if(oneFlag == 1){
        StartGame.lifeFlag = 1;
        RandomSceneLoader.LoadRandomScene();
        oneFlag = 0;
        }
      }
      flag++; //collides twice on start
    }
  }
}
