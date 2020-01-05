using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    public AudioClip soundJump;
    public AudioClip soundStun;
    public AudioClip soundItem;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // --- sound methods ---
    public void MakeJumpSound()
    {
        audioSource.PlayOneShot(soundJump);
    }
    public void MakeStunSound()
    {
        audioSource.PlayOneShot(soundStun);
    }
    public void MakeItemSound()
    {
        audioSource.PlayOneShot(soundItem);
    }
}
