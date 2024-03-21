using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //Instancia Singleton del AudioManager
    private static AudioManager instance;

    public static AudioManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<AudioManager>();            
            }
            return instance;
        }
    }

    public AudioSource[] music;
    public AudioSource[] sfx;

    // Start is called before the first frame update
    void Start()
    {
        PlayMusic(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayMusic(int musicToPlay)
    {
        music[musicToPlay].Play();
    }

    public void PlaySFX(int sfxToPlay)
    {
        sfx[sfxToPlay].Play();
    }

}
