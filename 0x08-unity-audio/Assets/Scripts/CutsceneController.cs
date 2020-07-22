using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneController : MonoBehaviour
{
	public GameObject mainCamera;
	public GameObject cutCamera;
	public GameObject player;
	public GameObject timerCanvas;

	public void CutsceneOver() {
		mainCamera.SetActive(true);
		player.GetComponent<PlayerController>().enabled = true;
		timerCanvas.SetActive(true);
		cutCamera.SetActive(false);
	}
}
