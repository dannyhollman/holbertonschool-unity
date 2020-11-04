using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioClip clickSound;
    public AudioClip gameOverSound;
    public AudioClip explosionSound;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayClick()
    {
        audioSource.clip = clickSound;
        audioSource.Play();
    }

    public void PlayGameOver()
    {
        audioSource.clip = gameOverSound;
        audioSource.Play();
    }

    public void PlayExplosion()
    {
        audioSource.clip = explosionSound;
        audioSource.Play();
    }
}
