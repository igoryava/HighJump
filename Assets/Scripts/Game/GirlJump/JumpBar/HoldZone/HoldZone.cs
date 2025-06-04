using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldZone : MonoBehaviour
{
    [SerializeField] private JumpSuccessState _successState;

    private void OnEnable()
    {
        _successState.Successed += OnEnd;
        _successState.Failed += OnEnd;
        _successState.FailedOver += OnEnd;
    }

    private void OnEnd()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        _successState.Successed -= OnEnd;
        _successState.Failed -= OnEnd;
        _successState.FailedOver -= OnEnd;
    }
}