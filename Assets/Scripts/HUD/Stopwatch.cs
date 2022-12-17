using System;
using UnityEngine;

public class Stopwatch : MonoBehaviour
{
    private bool _stopwatchActive = true;
    public float CurrentTime = 0;

    private void Update()
    {
        if (_stopwatchActive)
            CurrentTime += Time.deltaTime;
        TimeSpan time = TimeSpan.FromSeconds(CurrentTime);

    }

    public void StartStopWatch()
    {
        _stopwatchActive = true;
    }

    public void StopStopWatch()
    {
        _stopwatchActive = false;
    }

    public void ResetStopWatch()
    {
        CurrentTime = 0;
    }
}
