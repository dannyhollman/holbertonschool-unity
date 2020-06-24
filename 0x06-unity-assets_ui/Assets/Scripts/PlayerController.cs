using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public CharacterController controller;

	private Vector3 moveDir = Vector3.zero;
	public float jump = 5f;
	public float speed = 6f;
	public float gravity = -10f;
	bool isGrounded;	
	Vector3 velocity = Vector3.zero;
	public LayerMask groundMask;
	public Transform groundCheck;
	public Transform spawn;
	public Timer timer;

	void Update()
	{
		if (Input.GetKey(KeyCode.Escape))
		{
			FindObjectOfType<PauseMenu>().Pause();
		}

		if (controller.transform.position.y <= -20)
		{
			controller.enabled = false;
			transform.position = spawn.position;
			controller.enabled = true;
			timer.enabled = false;
		}
		/// Check if player is on the ground
		isGrounded = Physics.CheckSphere(groundCheck.position, 0.4f, groundMask);

		/// Make sure player is touching ground
		if (isGrounded && velocity.y < 0)
			velocity.y = -2f;

		/// Get movement input
		moveDir = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");

		/// Move player
		controller.Move(moveDir * speed * Time.deltaTime);

		/// Check for jump input
		if (Input.GetButtonDown("Jump") && isGrounded)
		{
			velocity.y = Mathf.Sqrt(jump * -2f * gravity);
		}
		
		/// Apply gravity
		velocity.y += gravity * Time.deltaTime;
		controller.Move(velocity * Time.deltaTime);
	}
}
