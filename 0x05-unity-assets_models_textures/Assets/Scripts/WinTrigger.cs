using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
	public Timer timer;
	public Text text;

	void OnTriggerEnter()
	{
		timer.Stop();
		text.fontSize = 60;
		text.color = Color.green;
	}
}
