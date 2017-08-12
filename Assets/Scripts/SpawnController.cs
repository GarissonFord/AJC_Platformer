using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour 
{

	public int maxPlatforms = 20;
	public GameObject platform;
	//The horizontal distance range between each platform
	/*
	public float horizontalMin = 14f;
	public float horizontalMax = 20f;
	*/
	//The vertical distance range between each platform
	/* However, we're trying to create a "clamp" so the platforms don't spawn 
	public float verticalMin = -6f;
	public float verticalMax = 6f;
	*/

	// Use this for initialization
	void Start () 
	{
		Spawn ();
	}

	void Spawn()
	{
		//The random range allows variation in the vertical component of the platforms
		Vector2 randomPosition = new Vector2 (25.0f, Random.Range(-9.0f, 5.0f));
		Instantiate (platform, randomPosition, Quaternion.identity);

		Invoke ("Spawn", 3.0f);
	}
}