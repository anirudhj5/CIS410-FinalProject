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
      private float gravityValue = -100.81f;
      private int jumpCount = 0;
      bool groundedPlayer = true;

      void Start()
      {
        controller = GetComponent<CharacterController>();
        RandomSceneLoader = gameObject.AddComponent<RandomSceneLoader>();
        rb = this.GetComponent<Rigidbody>();
        block_stop.SetActive(false);
      }

      // Update is called once per frame
      void Update()
      {


        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
            animator.SetBool("isJumping", false);
            jumpCount = 0;
        }

        Vector2 move = wasd.ReadValue<Vector2>();

        if(move.x != 0)
        {
          StartCoroutine(HideText());
        }
        animator.SetFloat("Speed", Mathf.Abs(move.x));

        if(Keyboard.current.spaceKey.wasPressedThisFrame && jumpCount < 2){ //if d is pressed and facing left
  	      animator.SetBool("isJumping", true);
          playerVelocity.y = 0f;
          groundedPlayer = false;
          jumpCount++;
          playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
  	    }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if(Keyboard.current.aKey.wasPressedThisFrame && rotateFlag){ //if d is pressed and facing left
  	      rb.transform.Rotate(new Vector3(0f, 180f, 0f)); //face right
  				rotateFlag = false; //if false player facing right
  	    }
  			if(Keyboard.current.dKey.wasPressedThisFrame && !rotateFlag){ //if d is pressed and facing right
  	      rb.transform.Rotate(new Vector3(0f, 180f, 0f)); //face left
  				rotateFlag = true; //if false player facing left
  	    }
        controller.Move(move * Time.deltaTime * speed);


        if(rb.transform.position.x < -37)
        {
          temp = new Vector3(74.0f,0f,0f);
          player.transform.position += temp;
        }
        else if (rb.transform.position.x > 37){
          temp = new Vector3(-74.0f,0f,0f);
          player.transform.position += temp;
        }
      }

      private void OnTriggerEnter(Collider other)
      {
        if (other.gameObject.name == "Ground Trigger")
        {
          groundedPlayer = true;
          Debug.Log("ground");
        }

        if (other.gameObject.name == "Mushroom Trigger")
        {
          animator.SetTrigger("Mushroom");
          animator.SetBool("isBig", true);
          block_stop.SetActive(true);
          StartGame.lifeFlag = 0;
        }
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
