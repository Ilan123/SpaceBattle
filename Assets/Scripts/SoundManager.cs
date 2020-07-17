using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] AudioSource themeMusic;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playThemeMusic()
    {
        themeMusic.Play();
    }

    public void stopThemeMusic()
    {
        themeMusic.Stop();
    }

    public void pauseThemeMusic()
    {
        themeMusic.Pause();
    }
}
