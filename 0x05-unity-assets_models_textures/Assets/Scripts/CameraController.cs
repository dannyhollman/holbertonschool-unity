using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public GameObject player;
	public float sens = 5;
	private float vertical = 0f;
	Vector3 offset;


	void Start()
	{
		/// Get camera offset from player
		offset = player.transform.position - transform.position;
	}

	void Update()
	{
		/// Get input from mouse
		float horizontal = Input.GetAxis("Mouse X") * sens;
		vertical += Input.GetAxis("Mouse Y") * sens;

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
