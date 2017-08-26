using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour 
{
	public Text scoreText;
	public AudioSource backgroundMusic;

	void Awake()
	{
		backgroundMusic = GetComponent<AudioSource> ();
		backgroundMusic.Play ();
	}

	void Update()
	{
		scoreText.text = "Score: " + Time.timeSinceLevelLoad.ToString();
	}

	public void GameOver()
	{
		backgroundMusic.Stop ();
	}
}
