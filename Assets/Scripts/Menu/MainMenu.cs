using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioClip MainMenuMusic;
    public AudioClip GameMusic;

    public void Awake()
    {
        SoundManager.Instance.PlayMusic(MainMenuMusic);
    }

    public void Play()
    {
        SoundManager.Instance.StopMusic();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SoundManager.Instance.PlayMusic(GameMusic);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
