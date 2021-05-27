using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace gameLogic
{
  public class PlayerControllerTurtle : MonoBehaviour
  {
      public Animator animator;
      public float speed;
      public float rotateSpeed;
      public InputAction wasd;
      public CharacterController controller;
      public GameObject player;
      public int countGames = 4;
      RandomSceneLoader RandomSceneLoader;

      void Awake()
      {
        Debug.Log("Turtle");
        controller = GetComponent<CharacterController>();
        RandomSceneLoader = gameObject.AddComponent<RandomSceneLoader>();
        speed = 5.5f * StartGame.gameSpeed;
      }

      void Update()
      {
        Vector2 move = wasd.ReadValue<Vector2>();
        animator.SetFloat("Speed", Mathf.Abs(move.x) +Mathf.Abs(move.y));


        controller.Move(move * Time.deltaTime * speed); //move player

        if(move != Vector2.zero) //if player not moving
        {
            transform.rotation = Quaternion.LookRotation(Vector3.back,move); //rotate player in direction of movement
        }

        if(transform.position.y > 21) //if player crossed road
        {
          StartGame.lifeFlag = 0;
          RandomSceneLoader.LoadRandomScene(); //load random scene
        }

      }

      void OnEnable()
      {
        wasd.Enable();
      }

      void OnDisable()
      {
        wasd.Disable();
      }
  }
}
