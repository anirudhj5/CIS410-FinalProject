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
    public GameObject balloon_string;
    public GameObject instrText;
    private float pop = 0;
    RandomSceneLoader RandomSceneLoader;
    public Animator animator;

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
            float scale = Random.value/15f; //random scale value from 0 to .2
            pop += scale; //track total scale
            balloon.transform.localScale += new Vector3(scale, scale, scale);//scale balloon by random scale
            balloon_string.transform.localScale += new Vector3(scale, scale/4, scale);//scale balloon by random scale
            if(pop > 1.5f){ //if total scale > 2
              pop = 0;
              animator.SetTrigger("BalloonPop");
              StartCoroutine(Wait());
              return;
            }
          }
      }

      IEnumerator Wait()
      {
        yield return new WaitForSeconds(.3f);
        balloon_string.SetActive(false);
        balloon.SetActive(false); //hide balloon aka pop
        StartGame.lifeFlag = 0;
        RandomSceneLoader.LoadRandomScene();
      }

      IEnumerator HideText()
      {
        yield return new WaitForSeconds(1.5f);
        instrText.SetActive(false);
      }
    }

  }
