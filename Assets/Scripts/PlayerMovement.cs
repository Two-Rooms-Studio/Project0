using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	//public vars
	[Range(0.5f, 5.0f)]
	[Tooltip("The walking speed of the player")]
	public float playerSpeed;

	[Range(0.5f, 5.0f)]
	[Tooltip("The sprint speed of the player, value is added to player walking speed")]
	public float playerSprintSpeed;

	[Range(50.0f, 300.0f)]
	[Tooltip("The energy bar of the player, for every 20 points of energy we have one second of running")]
	public float playerEnergyValue;
	//

	//private vars
	private Rigidbody2D rb; //players rigidbody
	private float leftRight;
	private float upDown;
	//


	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate () { //runs 50 times a second
		leftRight = Input.GetAxisRaw ("Horizontal");
		upDown = Input.GetAxisRaw ("Vertical");
		Vector2 movement = new Vector2 (leftRight, upDown);

		rb.velocity = Vector2.zero;
		if ((Input.GetKey (KeyCode.LeftShift)) && playerEnergyValue > 0) {
			movement = movement * (playerSpeed + playerSprintSpeed);
			playerEnergyValue = playerEnergyValue - 0.4f; //at this value every 20 points of energy equals one second of running

		} 
		else {
			movement = movement * playerSpeed;
		}
		rb.AddForce ((movement), ForceMode2D.Impulse); //implement our movement
	}
}
	