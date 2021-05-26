using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

namespace gameLogic
{
	public class PlayerControllerAsteroid : MonoBehaviour {

		public float speed;
	  public InputAction ad;
		private bool rotateFlag = true;

	  public CharacterController controller;
		private Rigidbody rb;

	  void Start()
	  {
	      controller = GetComponent<CharacterController>();
				rb = this.GetComponent<Rigidbody>();
				Debug.Log("Space");
	  }

	  void Update()
	  {
	    Vector2 inputVector = ad.ReadValue<Vector2>(); //input vector

			if(Keyboard.current.dKey.wasPressedThisFrame && rotateFlag){ //if d is pressed and facing left
	      rb.transform.Rotate(new Vector3(0f, 180f, 0f)); //face right
				rotateFlag = false; //if false player facing right
	    }
			if(Keyboard.current.aKey.wasPressedThisFrame && !rotateFlag){ //if d is pressed and facing right
	      rb.transform.Rotate(new Vector3(0f, 180f, 0f)); //face left
				rotateFlag = true; //if false player facing left
	    }
	    controller.Move(new Vector3(inputVector.x, 0f, 0f) * Time.deltaTime * speed); //move player
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
