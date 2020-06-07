using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Diagnostics;

public class Timer : MonoBehaviour
{
	public Text timer;
	public Stopwatch stopwatch = new Stopwatch();

	public void StartStopwatch()
	{
		stopwatch.Restart();
	}

	public void Stop()
	{
		stopwatch.Stop();
	}

	void Update()
	{
		TimeSpan ts = stopwatch.Elapsed;

		timer.text = String.Format(@"{0:m\:ss\.ff}", ts);
	}

}
