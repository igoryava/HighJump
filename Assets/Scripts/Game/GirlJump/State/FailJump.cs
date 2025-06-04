using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailJump : MonoBehaviour
{
    [SerializeField] private GameObject _failCanvas;
    [SerializeField] private GameObject _overPopUp;
    [SerializeField] private GameObject _failPopUp;
    [SerializeField] private JumpSuccessState _successState;

    private void OnEnable()
    {
        _successState.Failed += OnFailed;
        _successState.FailedOver += OnFailedOver;
    }

    private void OnFailedOver()
    {
        _failCanvas.SetActive(true);
        _overPopUp.SetActive(true);
    }

    private void OnFailed()
    {
        _failCanvas.SetActive(true);
        _failPopUp.SetActive(true);
    }

    private void OnDisable()
    {
        _successState.Failed -= OnFailed;
        _successState.FailedOver -= OnFailedOver;
    }
}