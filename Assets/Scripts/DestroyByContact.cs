using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DestroyByContact : MonoBehaviour 
{
	public Text gameOverText;

	void Start()
	{
		gameOverText.text = "";
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Player"))
		{
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
