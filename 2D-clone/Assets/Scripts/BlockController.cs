using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BlockController : MonoBehaviour
{
	private float previousTime;
	public static int width = 10;
	public static int height = 20;
	public static Transform[,] grid = new Transform[width, height];
	public static int clears = 0;
	public static float fallTime = 1.0f;
	public static int score = 0;
	public static int level = 1;


	void Start()
	{
		if (!CheckMove())
			GameOver();
	}
	// Update is called once per frame
	void Update()
	{
		if (!FindObjectOfType<UIController>().isPaused)
		{
			// Move block left
			if (Input.GetKeyDown("a") || Input.GetKeyDown("left"))
			{
				transform.position += new Vector3(-1, 0, 0);
				if (!CheckMove())
					transform.position -= new Vector3(-1, 0, 0);
			}
			// Move block right
			else if (Input.GetKeyDown("d") || Input.GetKeyDown("right"))
			{
				transform.position += new Vector3(1, 0, 0);
				if (!CheckMove())
					transform.position -= new Vector3(1, 0, 0);
			}
			// Rotate block
			else if (Input.GetKeyDown("w") || Input.GetKeyDown("up"))
			{
				transform.Rotate(0, 0, -90);
				if (!CheckMove())
					transform.Rotate(0, 0, 90);
			}
			// Make block fall
			if (Time.time - previousTime > ((Input.GetKey("s") || Input.GetKey("down")) ? fallTime / 10 : fallTime))
			{
				transform.position += new Vector3(0, -1, 0);
				if (!CheckMove())
				{
					transform.position -= new Vector3(0, -1, 0);
					UpdateGrid();
					FixGrid();
					FindObjectOfType<SpawnController>().SpawnBlock();
					this.enabled = false;
				}
				previousTime = Time.time;
			}
		}
	}

	// Check if move is valid
	bool CheckMove()
	{
		foreach (Transform child in transform)
		{
			int x = Mathf.RoundToInt(child.transform.position.x);
			int y = Mathf.RoundToInt(child.transform.position.y);


			if (x < 0 || x >= width || y < 0 || y >= height)
				return false;

			if (grid[x, y] != null && grid[x, y].parent != transform)
                return false;
		}
		return true;
	}

	void UpdateGrid()
	{
		foreach (Transform child in transform)
		{
			int x = Mathf.RoundToInt(child.transform.position.x);
			int y = Mathf.RoundToInt(child.transform.position.y);

			grid[x,y] = child;
		}

	}

	void FixGrid()
	{
		int lines = 0;
		for (int i = height - 1; i >= 0; i--)
		{
			if (HasLine(i))
			{
				lines++;
				clears++;
				// Increase level
				if (clears % 10 == 0 && fallTime > 0)
				{
					fallTime -= 0.1f;
					level++;
				}
				// Delete lines
				for (int j = 0; j < width; j++)
				{
					Destroy(grid[j, i].gameObject);
						grid[j, i] = null;
				}
				// Collapse blocks
				for (int x = i; x < height; x++)
					for (int j = 0; j < width; j++)
						if (grid[j, x] != null)
						{
							grid[j, x].transform.position += new Vector3(0, -1, 0);
							grid[j, x - 1] = grid[j, x];
							grid[j, x] = null;
						}
			}
		}
		AddScore(lines);
		FindObjectOfType<UIController>().UpdateScore(score);
	}

	bool HasLine(int i)
	{
		for (int j = 0; j < width; j++)
		{
			if (grid[j, i] == null)
				return false;
		}
		return true;
	}

	void AddScore(int lines)
	{
		if (lines == 1)
			score += (100 * level);
		else if (lines == 2)
			score += (300 * level);
		else if (lines == 3)
			score += (500 * level);
		else if (lines == 4)
			score += (800 * level);
	}

	void GameOver()
	{
		Debug.Log("Game Over!");
		this.enabled = false;
		FindObjectOfType<UIController>().SetHighScore(score);
		FindObjectOfType<UIController>().GameOver();
		//SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
