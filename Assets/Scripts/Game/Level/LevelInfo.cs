using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfo : MonoBehaviour
{
    [field: SerializeField] public Level Current;

    [SerializeField] private Level[] _levels;

    public event Action Bootstrapped;

    private void Start()
    {
        Bootstrap();
    }

    private void Bootstrap()
    {
        for (int i = 0; i < _levels.Length; i++)
        {
            if (_levels[i].Number == PlayerPrefs.GetInt("CurrentLevel", 1))
            {
                Current = _levels[i];
                Bootstrapped?.Invoke();
                return;
            }
        }
    }
}