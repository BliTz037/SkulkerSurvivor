using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Game,
    LevelUp
}

public class StateManager : MonoBehaviour
{
    // Singleton
    private static StateManager _instance;

    // State

    [HideInInspector]
    public State CurrentState = State.Game;

    private static readonly object locker = new object();


    public static StateManager Instance()
    {
        lock (locker)
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<StateManager>();
                if (_instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = typeof(StateManager).Name;
                    _instance = go.AddComponent<StateManager>();
                }
            }
            return _instance;
        }
    }
}
