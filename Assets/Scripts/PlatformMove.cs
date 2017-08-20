using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour {

	public float moveSpeed = 10.0f;
	public int timeSpeedMultiplier;
	public Rigidbody2D rb;

	void Awake()
	{
		//This should adjust the speed per each 10 seconds
		float timeOfCreation = Time.timeSinceLevelLoad;
		int timeCast = (int)timeOfCreation;
		timeSpeedMultiplier = timeCast / 10;
		moveSpeed += timeSpeedMultiplier;
		//Let's test this out...
		rb = GetComponent<Rigidbody2D> ();
		rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
		//Debug.Log (moveSpeed);
	}
}
