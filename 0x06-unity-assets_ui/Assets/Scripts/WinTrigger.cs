using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
	public Timer timer;
	public Text text;
	public Text endTime;
	public GameObject winCanvas;

	void OnTriggerEnter()
	{
		timer.Stop();
		//text.fontSize = 60;
		//text.color = Color.green;
		winCanvas.SetActive(true);
		endTime.text = text.text;
		timer.Win();
	}
}
