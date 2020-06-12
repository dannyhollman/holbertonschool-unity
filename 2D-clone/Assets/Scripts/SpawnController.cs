using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnController : MonoBehaviour
{
	public GameObject[] blocks;
    // Start is called before the first frame update
    void Start()
    {
        SpawnBlock();
    }

	public void SpawnBlock()
	{
		Instantiate(blocks[Random.Range(0, blocks.Length)], transform.position, Quaternion.identity);
	}
}
