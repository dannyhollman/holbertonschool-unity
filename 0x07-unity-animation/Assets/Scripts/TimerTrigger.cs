using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerTrigger : MonoBehaviour
{
	public Timer timer;
	public Text text;

	void OnTriggerExit(Collider other)
	{
		text.color = Color.white;
		text.fontSize = 48;
		timer.enabled = true;
		timer.RestartStopwatch();
	}
}
