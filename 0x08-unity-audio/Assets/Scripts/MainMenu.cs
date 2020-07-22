using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
	public AudioMixer audioMixer;
	private void Start()
	{
		// Set volume from PlayerPrefs
		if (PlayerPrefs.HasKey("BGM"))
			audioMixer.SetFloat("BGM", Mathf.Log10(PlayerPrefs.GetFloat("BGM")) * 20);
		if (PlayerPrefs.HasKey("SFX"))
			audioMixer.SetFloat("SFX", Mathf.Log10(PlayerPrefs.GetFloat("SFX")) * 20);
	}
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
