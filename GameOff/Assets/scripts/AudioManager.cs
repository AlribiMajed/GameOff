using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---------Music Source---------")]
    [SerializeField] AudioSource musicSource;
    [Header("---------SFX Source---------")]
    [SerializeField] AudioSource SFXSource;

    public AudioClip soundtrack;

    [Header("------Player----")]
    public AudioClip jump;
    public AudioClip sun;
    public AudioClip moon;
    public AudioClip earth;

    [Header("------Cannon-----")]
    public AudioClip fire;

    private void Start()
    {
        musicSource.clip = soundtrack;
        musicSource.Play();
    }
    public void PlaySFX(AudioClip sfx)
    {
        SFXSource.PlayOneShot(sfx);
    }



}
