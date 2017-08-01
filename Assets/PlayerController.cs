﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	//Used for the Flip() function
	public bool facingRight = true;

	//Tells us when the player is airborne 
	public bool jump;

	//So we can decide if a player can double jump
	public bool doubleJump;

	//i.e. Speed
	public float moveForce;
	public float maxSpeed;

	//Power of a jump
	public float jumpForce;

	//Rigidbody2D reference
	private Rigidbody2D rb;

	//Reference to the bullet prefab and where to spawn it
	public GameObject bullet;
	public GameObject bulletSpawn;

	//How fast a bullet can be fired
	public float fireRate;
	private float nextFire = 0.25f;

	//To check when the player is touching the ground
	public Transform groundCheck;
	public bool grounded;

	//Our GetAxis value for movement
	public float h;

	void Awake()
	{
		rb = GetComponent<Rigidbody2D> ();
	}

	void Update()
	{	
		//Uses a vertical linecast to see if the player is touching the ground
		grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));

		if (Input.GetButtonDown ("Jump") && grounded) 
		{
			grounded = false;
			jump = true;
		}
	}

	void FixedUpdate()
	{
		h = Input.GetAxis ("Horizontal");

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

		if(grounded)
		{
			doubleJump = false;
		}

		if (jump) 
		{
			//rb.AddForce(new Vector2(0f, jumpForce));
			rb.velocity = new Vector2(rb.velocity.x, jumpForce);
			jump = false;
			//Debug.Log ("Jumped");
		}

		//Double Jump
		if (Input.GetButtonDown("Jump") && !grounded && !doubleJump) 
		{
			rb.velocity = new Vector2 (rb.velocity.x, jumpForce);
			doubleJump = true;
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
