using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider _masterSlider, _musicSlider, _sfxSlider;

    public void MasterVolume()
    {
        SoundManager.Instance.ChangeMasterVolume(_masterSlider.value);
    }

    public void MusicVolume()
    {
        SoundManager.Instance.ChangeMusicVolume(_musicSlider.value);
    }

    public void SFXVolume()
    {
        SoundManager.Instance.ChangeEffectsVolume(_sfxSlider.value);
    }
}
