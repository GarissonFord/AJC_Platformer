using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour 
{
	public GameObject platform;

	//The vertical distance range between each platform
	// However, we're trying to create a "clamp" so the platforms don't spawn 
	public float verticalMin;
	public float verticalMax;


	// Use this for initialization
	void Start () 
	{
		Spawn ();
	}

	void Spawn()
	{
		//The random range allows variation in the vertical component of the platforms
		//The X value is always 25.0f because this is right off the screen
		Vector2 randomPosition = new Vector2 (25.0f, Random.Range(verticalMin, verticalMax));
		Instantiate (platform, randomPosition, Quaternion.identity);

		Invoke ("Spawn", 3.0f);
	}
}