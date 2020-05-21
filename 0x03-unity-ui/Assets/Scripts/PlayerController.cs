using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed = 500;
	public Rigidbody rb;
	private int health = 5;
	public Text scoreText;
	public Text healthText;
	public Text winLose;
	
	private int score;

	void Update () {
		if (health == 0)
		{
			Debug.Log("Game Over!");
			winLose.text = "Game Over!";
			winLose.color = Color.white;
			winLose.transform.parent.GetComponent<Image>().color = Color.red;
			winLose.transform.parent.gameObject.SetActive(true);
			StartCoroutine(LoadScene(3));
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey("w"))
			rb.AddForce(0, 0, speed * Time.deltaTime);
		if (Input.GetKey("s"))
			rb.AddForce(0, 0, -(speed * Time.deltaTime));
		if (Input.GetKey("a"))
			rb.AddForce(-(speed * Time.deltaTime), 0 , 0);
		if (Input.GetKey("d"))
			rb.AddForce(speed * Time.deltaTime, 0 ,0);
		if (Input.GetKey(KeyCode.Escape))
			SceneManager.LoadScene("Menu");
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Pickup")
		{
			score += 1;
			Destroy(other.gameObject);
			SetScoreText();
		}

		if (other.tag == "Trap")
		{
			health -= 1;
			SetHealthText();
		}

		if (other.tag == "Goal")
		{
			winLose.text = "You Win!";
			winLose.color = Color.black;
			winLose.transform.parent.GetComponent<Image>().color = Color.green;
			winLose.transform.parent.gameObject.SetActive(true);
		}
	}

	void SetScoreText()
	{
		scoreText.text = "Score: " + score;
	}

	void SetHealthText()
	{
		healthText.text = "Health: " + health;
	}

	IEnumerator LoadScene(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
