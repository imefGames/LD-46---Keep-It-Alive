using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedPlaySound : MonoBehaviour
{
    public int PlaySound = 0;
    public AudioClip Clip;

    void Update()
    {
        if (PlaySound != 0)
        {
            PlaySound = 0;
            AudioSource source = GetComponent<AudioSource>();
            source.Stop();
            source.clip = Clip;
            source.Play();
        }
    }
}
