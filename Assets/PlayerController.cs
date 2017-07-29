using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D rb;

	//Used for GetAxis
	public float h;
	//Fastest the player can move
	public float moveForce;
	public float maxSpeed;

	//Let's us know when the player is airborne or on the ground
	public bool jump, grounded;
	public Transform groundCheck;
	//Helps determine jump height
	public float jumpForce;

	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Uses a 2D linecast to see if the player is touching the ground
		grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));

		//If the jump button was pressed while the player is grounded
		if (Input.GetButtonDown ("Jump") && grounded) 
		{
			grounded = false;
			jump = true;
		}
	}

	void FixedUpdate () {
		//Movement
		h = Input.GetAxis ("Horizontal");

		if (h * rb.velocity.x < maxSpeed) 
		{
			rb.AddForce (Vector2.right * h * moveForce);
		}

		//Makes the player jump
		if (jump) 
		{
			//rb.AddForce(new Vector2(0f, jumpForce));
			rb.velocity = new Vector2(rb.velocity.x, jumpForce);
			jump = false;
			//Debug.Log ("Jumped");
		}
	}
}
