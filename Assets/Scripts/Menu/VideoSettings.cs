using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class VideoSettings : MonoBehaviour
{
    [Header("Dropdowns")]
    public Dropdown Resolution;
    public Dropdown display;

    private FullScreenMode screenMode;

    void ScreenOptions(string mode)
    {
        if (mode == "Fullscreen")
            screenMode = FullScreenMode.ExclusiveFullScreen;
        else if (mode == "Windowed")
            screenMode = FullScreenMode.Windowed;
        else
            screenMode = FullScreenMode.FullScreenWindow;
        Screen.fullScreenMode = screenMode;
    }

    void ScreenInitialize()
    {
        if (Screen.fullScreenMode == FullScreenMode.ExclusiveFullScreen) {
            display.value = 0;
            screenMode = FullScreenMode.ExclusiveFullScreen;
        } else {
            display.value = 1;
            screenMode = FullScreenMode.Windowed;
        }
        display.RefreshShownValue();
    }

    public void SetResolution()
    {
        switch(Resolution.value)
        {
            case 0:
                Screen.SetResolution(2560, 1440, true);
                break;

            case 1:
                Screen.SetResolution(1920, 1080, true);
                break;

            case 2:
                Screen.SetResolution(1366, 768, true);
                break;
        }
    }

    void Start()
    {
        ScreenInitialize();

        display.onValueChanged.AddListener(delegate {ScreenOptions(display.options[display.value].text);});
    }
}
