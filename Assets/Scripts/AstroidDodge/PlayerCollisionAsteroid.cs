using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;
using static gameLogic.RandomSceneLoader;

namespace gameLogic
{
  public class PlayerCollisionAsteroid : MonoBehaviour
  {
    private int oneFlag = 1;
    public GameObject instrText;
    RandomSceneLoader RandomSceneLoader;
    public Animator animator;

    void Awake()
    {
      RandomSceneLoader = gameObject.AddComponent<RandomSceneLoader>();
      StartGame.lifeFlag = 0;
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
      if(other.gameObject.name == "Asteroid(Clone)")
      {
        Debug.Log("hit");
        if(oneFlag == 1)
        {
        oneFlag = 0;
        animator.SetTrigger("Explode");
        StartCoroutine(Wait());
        }
      }
    }

    IEnumerator HideText()
    {
      yield return new WaitForSeconds(1.5f);
      instrText.SetActive(false);
    }

    IEnumerator Wait()
    {
      yield return new WaitForSeconds(.8f);
      StartGame.lifeFlag = 1;
      RandomSceneLoader.LoadRandomScene();

    }
  }
}
