using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class UIManager : MonoBehaviour
{
    public GameObject playAgainButton;
    public GameObject resetButton;
    public GameObject exitButton;
    public GameObject startButton;

    public GameObject scoreText;
    public GameObject gameOverText;
    public GameObject ammoText;
    public GameObject surfaceText;

    private ARSession arSession;

    private void Start()
    {
        arSession = FindObjectOfType<ARSession>();
    }

    public void PlayGameUI()
    {
        playAgainButton.SetActive(false);
        resetButton.SetActive(true);
        exitButton.SetActive(true);
        startButton.SetActive(false);

        surfaceText.SetActive(false);
        gameOverText.SetActive(false);
        scoreText.SetActive(true);
        ammoText.SetActive(true);

        scoreText.GetComponent<Text>().text = "0";
    }

    public void GameOverUI()
    {
        playAgainButton.SetActive(true);
        resetButton.SetActive(true);
        exitButton.SetActive(true);
        startButton.SetActive(false);

        surfaceText.SetActive(false);
        gameOverText.SetActive(true);
        scoreText.SetActive(true);
        ammoText.SetActive(false);
    }
    

    public void ResetGame()
    {
        arSession.Reset();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void UpdateAmmo()
    {
        GameManager.ammo -= 1;
        ammoText.GetComponent<Text>().text = GameManager.ammo.ToString();
    }

    public void UpdateScore()
    {
        GameManager.score += 10;
        GameManager.targets -= 1;
        scoreText.GetComponent<Text>().text = "Score: " + GameManager.score.ToString();
    }

}
