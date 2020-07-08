using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

	public void LevelSelect(int level)
	{
		SceneManager.LoadScene(level);
	}

	public void Options()
	{
		PlayerPrefs.SetInt("lastScene", 0);
		SceneManager.LoadScene(1);
	}

	public void Exit()
	{
		Application.Quit();
	}
}
