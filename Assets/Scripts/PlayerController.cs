using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	//Used for the Flip() function
	public bool facingRight = true;

	//Tells us when the player is airborne 
	public bool jump;

	//i.e. Speed
	public float moveForce;
	public float maxSpeed;

	//Power of a jump
	public float jumpForce;

	//Number of small "double" jumps that can be performed after a single jump
	//Think Flappy Bird or the old Helicopter browser game
	public int maxNumSecondJumps;
	//How many the player has currently taken
	public int numSecondJumpsTaken;

	public bool secondaryJumped;

	//Rigidbody2D reference
	private Rigidbody2D rb;

	//To check when the player is touching the ground
	public Transform groundCheck;
	public bool grounded;

	Animator anim;

	//Our GetAxis value for movement
	public float h;

	void Awake()
	{
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	void Update()
	{	
		//Uses a vertical linecast to see if the player is touching the ground
		grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));

		//First Jump
		if (Input.GetButtonDown ("Jump") && grounded) 
		{
			jump = true;
		}

		//Secondary Jumps
		if (Input.GetButtonDown ("Jump") && (!grounded) && (numSecondJumpsTaken < maxNumSecondJumps)) 
		{
			secondaryJumped = true;
		}
	}

	void FixedUpdate()
	{
		h = Input.GetAxis ("Horizontal");

		//Controls animations
		if (h != 0 && grounded) 
		{
			anim.SetBool ("isMoving", true);
		} 
		else if(h == 0 && grounded)
		{
			anim.SetBool ("isMoving", false);
		}

		if (grounded) 
		{
			numSecondJumpsTaken = 0;
			secondaryJumped = false;
			anim.SetBool ("jump", false);
			anim.SetBool ("secondaryJump", false);
			anim.SetBool ("grounded", true);
		}

		//The following two conditionals create a speed cap
		if (h * rb.velocity.x < maxSpeed) 
		{
			rb.AddForce (Vector2.right * h * moveForce);
		}

		if (Mathf.Abs (rb.velocity.x) > maxSpeed) 
		{
			//Mathf.Sign returns -1 or 1 depending on the sign of the input
			rb.velocity = new Vector2 (Mathf.Sign (rb.velocity.x) * maxSpeed, rb.velocity.y);
		}

		//Flips when hitting 'right' and facing left
		if (h > 0 && !facingRight)
			Flip ();
		//Flips when hitting 'left' and facing right
		else if (h < 0 && facingRight)
			Flip ();

		if (jump && !secondaryJumped) 
		{
			rb.velocity = new Vector2(rb.velocity.x, jumpForce);
			jump = false;
			anim.SetBool ("jump", true);
			anim.SetBool ("grounded", false);
			Debug.Log ("Jumped");
		}

		//Do a series of mini jumps
		if (secondaryJumped)
		{
			//Do a significantly smaller jump
			anim.SetBool("secondaryJump", true);
			rb.velocity = new Vector2(rb.velocity.x, jumpForce * 0.5f);
			//Increment the number of secondary jumps taken
			numSecondJumpsTaken++;
			secondaryJumped = false;
			Debug.Log ("Secondary Jumped");
		}
	}

	//Changes rotation of the player
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
} 
