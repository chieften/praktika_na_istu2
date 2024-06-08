using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundofBtn : MonoBehaviour
{
    public AudioSource soundPlay;

    public void PlayThisSongEffect()
    {
        soundPlay.Play();
    }
}
