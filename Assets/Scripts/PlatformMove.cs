using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour {

	public float moveSpeed;
	public Rigidbody2D rb;

	void Awake()
	{
		rb = GetComponent<Rigidbody2D> ();
		rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
	}
}
