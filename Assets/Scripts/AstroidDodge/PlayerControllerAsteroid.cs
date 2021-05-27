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
	  }

	  void Update()
	  {
	    Vector2 inputVector = ad.ReadValue<Vector2>(); //input vector

			if(Keyboard.current.dKey.wasPressedThisFrame)
			{ //if d is pressed and facing left
	      rb.transform.eulerAngles = new Vector3(180f,-5f,0f); //face right
	    }
			if(Keyboard.current.aKey.wasPressedThisFrame)
			{ //if d is pressed and facing right
	      rb.transform.eulerAngles = new Vector3(180f,5f,0f); //face left
	    }

			if(moveLock)
			{
				controller.Move(new Vector3(inputVector.x, 0f, 0f) * Time.deltaTime * speed); //move player
				if(Keyboard.current.spaceKey.wasPressedThisFrame && fire)
				{ //if d is pressed and facing left
					fire = false;
					Fire_Laser();
				}
			}

	  }

		void Fire_Laser()
		{
			GameObject Laser = Instantiate(laser) as GameObject;
			rbLaser = Laser.GetComponent<Rigidbody>();
			rbLaser.transform.position = new Vector3(rb.transform.position.x, 8f, 0f);
			StartCoroutine(Laser_Cooldown());
		}

		IEnumerator Laser_Cooldown()
		{
			 yield return new WaitForSeconds(.4f);
			 fire = true;
			 Debug.Log("fire recharge");
		}

		private void OnTriggerEnter(Collider other)
		{
			moveLock = true;
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
