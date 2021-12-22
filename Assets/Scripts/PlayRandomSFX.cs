using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomSFX : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] audioClipArray;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Play a random SFX from the array
    /// </summary>
    public void RandomSFX()
    {
        audioSource.clip = audioClipArray[Random.Range(0, audioClipArray.Length)];
        audioSource.PlayOneShot(audioSource.clip);
    }
}
