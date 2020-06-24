using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public GameObject player;
	public float sens = 5;
	public bool isInverted = false;
	private float vertical = 0f;
	Vector3 offset;


	void Start()
	{
		/// Get camera offset from player
		offset = player.transform.position - transform.position;
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	void Update()
	{
		isInverted = Convert.ToBoolean(PlayerPrefs.GetInt("inverted", 0));
		/// Get input from mouse
		float horizontal = Input.GetAxis("Mouse X") * sens;

        if (!isInverted)
            vertical += Input.GetAxis("Mouse Y") * sens;
        else
            vertical += -(Input.GetAxis("Mouse Y") * sens);

        /// Clamp rotation on Y axis
        vertical = Mathf.Clamp(vertical, -40, 40);

		/// Rotate player based on input
		player.transform.Rotate(0, horizontal, 0);

		/// Calculate angle of player
		float desiredAngle = player.transform.eulerAngles.y;

		/// Convert to Euler angle
		Quaternion rotation = Quaternion.Euler(-vertical , desiredAngle, 0);

		/// Update camera position
		transform.position = player.transform.position - (rotation * offset);

		/// Look at player
		transform.LookAt(player.transform);
	}
}
