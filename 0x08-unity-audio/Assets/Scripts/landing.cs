using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class landing : StateMachineBehaviour
{
    public AudioClip landingGrass;
    public AudioMixerGroup mixer;
    private AudioSource audioSource;
    private GameObject player;
    public void OnStateUpdate()
    {
        player = GameObject.Find("Player");
        audioSource = player.GetComponent<AudioSource>();
        if (!audioSource.isPlaying && audioSource.clip != landingGrass)
        {
            audioSource.outputAudioMixerGroup = mixer;
            audioSource.clip = landingGrass;
            audioSource.PlayOneShot(landingGrass);
        }
    }
}
