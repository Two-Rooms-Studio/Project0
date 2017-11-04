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
	//

	//private vars
	private Rigidbody2D rb; //players rigidbody
	private float leftRight;
	private float upDown;
	public float playerEnergyValue = player.getEnergy();
	//


	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate () { //runs 50 times a second
		leftRight = Input.GetAxisRaw ("Horizontal");
		upDown = Input.GetAxisRaw ("Vertical");
		Vector2 movement = new Vector2 (leftRight, upDown);
		playerEnergyValue = player.getEnergy ();

		rb.velocity = Vector2.zero;
		//Move the actual sprinting mechanic inside of playerStats and simply check for the LeftShift here, have sprinting return a bool to know which movement to use
		if ((Input.GetKey (KeyCode.LeftShift)) && playerEnergyValue > 0.4f) { // since we remove .4 energy each time
			player.isDrainingEnergy();
			movement = movement * (playerSpeed + playerSprintSpeed);
			playerEnergyValue = playerEnergyValue - 0.4f; //at this value every 20 points of energy equals one second of running
			player.setEnergy(playerEnergyValue);
		} 
		else {
			player.isNotDrainingEnergy();
			movement = movement * playerSpeed;
		}
		rb.AddForce ((movement), ForceMode2D.Impulse); //implement our movement
	}
}
	