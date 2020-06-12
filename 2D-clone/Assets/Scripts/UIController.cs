using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
	public Text scoreText;
	public Text highScore;
	public GameObject gameOver;
	public GameObject pauseMenu;
	public bool isPaused = false;

	public void Start()
	{
		gameOver.SetActive(false);
		pauseMenu.SetActive(false);
		Time.timeScale = 1;
		highScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0);
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (!pauseMenu.activeInHierarchy)
			{
				pauseMenu.SetActive(true);
				Time.timeScale = 0;
				isPaused = true;
			}
			else
			{
				pauseMenu.SetActive(false);
				Time.timeScale = 1;
				isPaused = false;
			}
		}
	}


	public void UpdateScore(int score)
	{
		scoreText.text = "Score: " + score;
	}

	public void SetHighScore(int score)
	{
		if (score > PlayerPrefs.GetInt("HighScore", 0))
		{
			PlayerPrefs.SetInt("HighScore", score);
			PlayerPrefs.Save();
		}
	}

	public void RestartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void GameOver()
	{
		gameOver.SetActive(true);
	}

	public void LoadMainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}
}
