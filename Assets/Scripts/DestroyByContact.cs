using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DestroyByContact : MonoBehaviour 
{
	public Text gameOverText;
	public GameObject gameOverImage;
	//public AudioSource deathAudio;

	public AudioClip death, gameOverAudio;
	public AudioSource audio;

	//public AudioSource gameOverAudio;

	void Start()
	{
		audio = GetComponent<AudioSource> ();

		gameOverText.text = "";
		gameOverImage.SetActive (false);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Player"))
		{
			//deathAudio.Play ();
			audio.PlayOneShot(death, 1.0f);
			Invoke ("GameOver", 3.0f);
		}
		Destroy (other.gameObject);
	}

	void GameOver()
	{
		//gameOverAudio.Play ();
		audio.PlayOneShot(gameOverAudio);
		gameOverImage.SetActive (true);
		gameOverText.text = "Restarting...";
		Invoke("RestartGame", 6.0f);
	}

	void RestartGame()
	{
		SceneManager.LoadScene ("Level_1");
	}
}
