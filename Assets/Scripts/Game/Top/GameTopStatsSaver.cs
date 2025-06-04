using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTopStatsSaver : MonoBehaviour
{
    [SerializeField] private JumpSuccessState _successState;

    [SerializeField] private LevelInfo _info;

    [SerializeField] private JumpHeightUi _jumpHeight;

    private void OnEnable()
    {
        _successState.Successed += OnSuccessed;
        _successState.Failed += OnFailed;
        _successState.FailedOver += OnFailed;
        _jumpHeight.HeightCalculated += OnHeightCalculated;
    }

    private void OnFailed()
    {
        PlayerPrefs.SetInt("Loses", PlayerPrefs.GetInt("Loses", 1) + 1);
    }

    private void OnSuccessed()
    {
        PlayerPrefs.SetInt("Wins", PlayerPrefs.GetInt("Wins", 1) + 1);
    }

    private void OnHeightCalculated(float height)
    {
        if (PlayerPrefs.GetFloat("TopHeight", 0) < height)
        {
            PlayerPrefs.SetFloat("TopHeight", height);

            PlayerPrefs.SetInt("TopLevel", _info.Current.Number);
        }
    }

    private void OnDisable()
    {
        _successState.Successed -= OnSuccessed;
        _successState.Failed -= OnFailed;
        _successState.FailedOver -= OnFailed;
        _jumpHeight.HeightCalculated -= OnHeightCalculated;
    }
}