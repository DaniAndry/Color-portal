using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SondButton : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;

    public void Play()
    {
        _audio.Play();
    }

}
