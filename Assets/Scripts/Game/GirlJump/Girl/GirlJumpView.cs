using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlJumpView : MonoBehaviour
{
    [SerializeField] private JumpSuccessState _successState;

    [SerializeField] private SpriteRenderer _spriteRenderer;

    [SerializeField] private Sprite _start;
    [SerializeField] private Sprite _fail;
    [SerializeField] private Sprite _success;

    [SerializeField] private JumpBar _bar;

    private void OnEnable()
    {
        _bar.Start += OnStart;

        _successState.Successed += SuccessJump;
        _successState.Failed += FailJump;
        _successState.FailedOver += FailJump;
    }

    private void OnStart()
    {
        _spriteRenderer.sprite = _start;
    }

    public void SuccessJump()
    {
        _spriteRenderer.sprite = _success;
    }

    public void FailJump()
    {
        _spriteRenderer.sprite = _fail;
    }

    private void OnDisable()
    {
        _bar.Start -= OnStart;

        _successState.Successed -= SuccessJump;
        _successState.Failed -= FailJump;
        _successState.FailedOver -= FailJump;
    }
}