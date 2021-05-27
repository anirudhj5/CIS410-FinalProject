using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

namespace gameLogic
{
	public class PlayerControllerAsteroid : MonoBehaviour {

		public float speed;
	  public InputAction ad;
		public GameObject laser;
		private bool fire = true;
		private bool moveLock = false;

	  public CharacterController controller;
		private Rigidbody rb;
		private Rigidbody rbLaser;

	  void Start()
	  {
	      controller = GetComponent<CharacterController>();
				rb = this.GetComponent<Rigidbody>();
				Debug.Log("Space");
				speed = 18 * StartGame.gameSpeed;
	  }

	  void Update()
	  {
	    Vector2 inputVector = ad.ReadValue<Vector2>(); //input vector

			if(Keyboard.current.dKey.wasPressedThisFrame) //if d is pressed
			{
	      rb.transform.eulerAngles = new Vector3(180f,-5f,0f); //tilt right
	    }
			if(Keyboard.current.aKey.wasPressedThisFrame) //if a pressed
			{
	      rb.transform.eulerAngles = new Vector3(180f,5f,0f); //tilt left
	    }

			if(moveLock) //dont havewhile explosion animation
			{
				controller.Move(new Vector3(inputVector.x, 0f, 0f) * Time.deltaTime * speed); //move player
				if(Keyboard.current.spaceKey.wasPressedThisFrame && fire)
				{ //if d is pressed and facing left
					fire = false; //no rapid fire lasers
					Fire_Laser(); //fire laser
				}
			}

	  }

		void Fire_Laser()
		{
			GameObject Laser = Instantiate(laser) as GameObject; //create laser
			rbLaser = Laser.GetComponent<Rigidbody>();
			rbLaser.transform.position = new Vector3(rb.transform.position.x, 8f, 0f); //place laser at front of ship
			StartCoroutine(Laser_Cooldown()); //recharge timer
		}

		IEnumerator Laser_Cooldown()
		{
			 yield return new WaitForSeconds(.4f/StartGame.gameSpeed);
			 fire = true; //allow another shot to fire
		}

		private void OnTriggerEnter(Collider other)
		{
			moveLock = true; //stop ability to move
		}

		void OnEnable()
	  {
	    ad.Enable();
	  }

	  void OnDisable()
	  {
	    ad.Disable();
	  }

	}
}
