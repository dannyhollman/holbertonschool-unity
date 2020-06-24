using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	public PlayerController playerController;
	public CameraController cameraController;
	public Timer timer;

	public void Pause()
	{
		PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
		gameObject.SetActive(true);
		//gameObject.GetComponent<Canvas>().enabled = true;
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = true;
		playerController.enabled = false;
		cameraController.enabled = false;
		timer.Stop();
	}

	public void Resume()
	{
		//gameObject.GetComponent<Canvas>().enabled = false;
		gameObject.SetActive(false);
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		playerController.enabled = true;
		cameraController.enabled = true;
		timer.StartStopwatch();
	}

	public void Restart()
	{
		Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.name);
	}

	public void MainMenu()
	{
		SceneManager.LoadScene(0);
	}

	public void Options()
	{
		SceneManager.LoadScene(1);
	}
}
