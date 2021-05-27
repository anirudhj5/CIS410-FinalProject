using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

namespace gameLogic
{
  public class SizeIncrease : MonoBehaviour
  {
    public GameObject balloon;
    public GameObject instrText;
    private float pop = 0;
    RandomSceneLoader RandomSceneLoader;

      void Awake()
      {
          Debug.Log("balloon");
          RandomSceneLoader = gameObject.AddComponent<RandomSceneLoader>();
          StartGame.lifeFlag = 1;
      }

      void OnSceneLoaded()
      {
          balloon = GetComponent<GameObject>();
          instrText = GetComponent<GameObject>();

      }

      void Update(){
          if(Keyboard.current.fKey.wasPressedThisFrame){ //if f is pressed
            StartCoroutine(HideText()); //hide instructions
            float scale = Random.value/5f; //random scale value from 0 to .2
            pop += scale; //track total scale
            balloon.transform.localScale += new Vector3(scale, scale, scale);//scale balloon by random scale
            if(pop > 4.7f){ //if total scale > 4.8
              balloon.SetActive(false); //hide balloon aka pop
              StartGame.lifeFlag = 0;
              RandomSceneLoader.LoadRandomScene();
              return;
            }
          }
      }

      IEnumerator HideText()
      {
        yield return new WaitForSeconds(1.5f);
        instrText.SetActive(false);
      }
    }

  }
