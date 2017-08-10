using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyByContact : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Player"))
		{
			Invoke("RestartGame", 3.0f);
		}
		Destroy (other.gameObject);
	}

	void RestartGame()
	{
		SceneManager.LoadScene ("Level_1");
	}
}
