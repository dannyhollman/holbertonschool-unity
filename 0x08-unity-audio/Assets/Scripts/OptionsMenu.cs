using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
	public bool inverted = false;
	public Toggle toggle;
	public Slider BGM;
	public Slider SFX;

	public void Start()
	{
		if (PlayerPrefs.GetInt("inverted") == 1)
			toggle.isOn = true;
		else
			toggle.isOn = false;

		BGM.value = PlayerPrefs.GetFloat("BGM", 1);
		SFX.value = PlayerPrefs.GetFloat("SFX", 1);

	}

	public void Back()
	{
		SceneManager.LoadScene(PlayerPrefs.GetInt("lastScene", 0));
	}

	public void Apply()
	{
		Debug.Log(inverted);
		PlayerPrefs.SetInt("inverted", Convert.ToInt32(inverted));
		PlayerPrefs.SetFloat("BGM", BGM.value);
		PlayerPrefs.SetFloat("SFX", SFX.value);
	}

	public void Toggle()
	{
		inverted = !inverted;
	}
}
