﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DestroyByContact : MonoBehaviour 
{
	public Text gameOverText;
	public GameObject gameOverImage;

	void Start()
	{
		gameOverText.text = "";
		gameOverImage.SetActive (false);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Player"))
		{
			gameOverImage.SetActive (true);
			gameOverText.text = "Game Over, you fuck";
			Invoke("RestartGame", 3.0f);
		}
		Destroy (other.gameObject);
	}

	void RestartGame()
	{
		SceneManager.LoadScene ("Level_1");
	}
}
