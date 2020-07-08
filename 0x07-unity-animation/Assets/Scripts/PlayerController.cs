using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public CharacterController controller;

	private Vector3 moveDir = Vector3.zero;
	public float jump = 5f;
	public float speed = 6f;
	public float rotationSpeed = 3f;
	public float gravity = -10f;
	bool isGrounded;	
	Vector3 velocity = Vector3.zero;
	public LayerMask groundMask;
	public Transform groundCheck;
	public Transform spawn;
	public Timer timer;
	public PauseMenu pauseMenu;
	public Animator animator;

	void Update()
	{
		if (Input.GetKey(KeyCode.Escape))
		{
			//FindObjectOfType<PauseMenu>().Pause();
			pauseMenu.Pause();
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
		animator.SetBool("isGrounded", isGrounded);

		if (Input.GetKey("d"))
		{
			transform.Rotate(Vector3.up * speed);
		}
		else if (Input.GetKey("a"))
		{
			transform.Rotate(-Vector3.up * speed);
		}

		/// Make sure player is touching ground
		if (isGrounded && velocity.y < 0)
			velocity.y = -2f;

		/// Get movement input
		moveDir = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");


		// Animation triggers
		if (controller.velocity.y != 0)
			animator.SetBool("Jumping", true);
		else
			animator.SetBool("Jumping", false);

		if ((Input.GetKey("w") || Input.GetKey("s"))&& isGrounded)
			animator.SetBool("Running", true);
		else
			animator.SetBool("Running", false);

		if (controller.transform.position.y <= -10)
			animator.SetBool("Falling", true);
		else
			animator.SetBool("Falling", false);

		/// Check for jump input
		if (Input.GetButtonDown("Jump") && isGrounded)
		{
			animator.SetTrigger("Jump");
			velocity.y = Mathf.Sqrt(jump * -2f * gravity);
		}
		
		/// Apply gravity
		velocity.y += gravity * Time.deltaTime;

		// Move player
		controller.Move((velocity * Time.deltaTime) + (moveDir * speed * Time.deltaTime));
	}
}
