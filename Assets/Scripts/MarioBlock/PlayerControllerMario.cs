using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace gameLogic
{
  public class PlayerControllerMario : MonoBehaviour
  {
      public float speed;
      public int jumpPower;
      public float rotateSpeed;
      public InputAction wasd;
      private Vector3 playerVelocity;
      public CharacterController controller;
      public GameObject player;
      public int countGames = 4;
      public Animator animator;
      public GameObject contrText;
      private bool rotateFlag = true;
      Vector3 temp;
      private Rigidbody rb;
      RandomSceneLoader RandomSceneLoader;
      public GameObject block_stop;
      private float jumpHeight = 2.6f;
      private float gravityValue = -100.81f * StartGame.gameSpeed;
      private int jumpCount = 0;
      bool groundedPlayer = true;

      void Start()
      {
        controller = GetComponent<CharacterController>();
        RandomSceneLoader = gameObject.AddComponent<RandomSceneLoader>();
        rb = this.GetComponent<Rigidbody>();
        rb.mass = rb.mass * StartGame.gameSpeed;
        block_stop.SetActive(false);
        speed = 12 * StartGame.gameSpeed;
        jumpPower = 15 * StartGame.gameSpeed;
        StartGame.lifeFlag = 1;
      }

      // Update is called once per frame
      void Update()
      {

        //if ground and not moving up or down
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
            animator.SetBool("isJumping", false); //stop jump animation
            jumpCount = 0; //reset jump count
        }

        Vector2 move = wasd.ReadValue<Vector2>();

        if(move.x != 0)
        {
          StartCoroutine(HideText());
        }
        animator.SetFloat("Speed", Mathf.Abs(move.x)); //set animator speed to trigger walk animation

        if(Keyboard.current.spaceKey.wasPressedThisFrame && jumpCount < 2){ //if space is pressed and havent doubble jumped
  	      animator.SetBool("isJumping", true);
          playerVelocity.y = 0f;
          groundedPlayer = false;
          jumpCount++;
          playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
  	    }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime); //move up/down
        controller.Move(move * Time.deltaTime * speed); //move left/right

        if(Keyboard.current.aKey.wasPressedThisFrame && rotateFlag){ //if d is pressed and facing left
  	      rb.transform.Rotate(new Vector3(0f, 180f, 0f)); //face right
  				rotateFlag = false; //if false player facing right
  	    }
  			if(Keyboard.current.dKey.wasPressedThisFrame && !rotateFlag){ //if d is pressed and facing right
  	      rb.transform.Rotate(new Vector3(0f, 180f, 0f)); //face left
  				rotateFlag = true; //if false player facing left
  	    }

        if(rb.transform.position.x < -37) //if off left side screen put on right side
        {
          temp = new Vector3(74.0f,0f,0f);
          player.transform.position += temp;
        }
        else if (rb.transform.position.x > 37){ //if off right side screen put on temp side
          temp = new Vector3(-74.0f,0f,0f);
          player.transform.position += temp;
        }
      }

      private void OnTriggerEnter(Collider other)
      {
        if (other.gameObject.name == "Ground Trigger") //if hits ground
        {
          groundedPlayer = true;
        }

        if (other.gameObject.name == "Mushroom Trigger")
        {
          animator.SetTrigger("Mushroom"); //play mushroom animation
          animator.SetBool("isBig", true); //set large state
          block_stop.SetActive(true);
          StartGame.lifeFlag = 0;
          StartCoroutine(End()); //end
        }
      }

      IEnumerator End()
      {
        yield return new WaitForSeconds(2f);
        RandomSceneLoader.LoadRandomScene();
      }

      IEnumerator HideText()
      {
        yield return new WaitForSeconds(1.5f);
        contrText.SetActive(false);
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
