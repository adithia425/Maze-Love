using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource audioSource;


    public AudioClip sfxGetItem;
    public AudioClip sfxGetBigger;
    public AudioClip sfxGetWin;
    public AudioClip sfxGetDie;
    public AudioClip sfxButton;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    public void PlaySFX(SFX sfx)
    {
        switch (sfx)
        {
            case SFX.GETITEM:
                audioSource.PlayOneShot(sfxGetItem);
                break;
            case SFX.BIGGER:
                audioSource.PlayOneShot(sfxGetBigger);
                break;
            case SFX.WIN:
                audioSource.PlayOneShot(sfxGetWin);
                break;
            case SFX.DIE:
                audioSource.PlayOneShot(sfxGetDie);
                break;
            case SFX.BUTTON:
                audioSource.PlayOneShot(sfxButton);
                break;
        }
    }
}

public enum SFX
{
    GETITEM,
    BIGGER,
    WIN,
    DIE,
    BUTTON
}
