using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessJump : MonoBehaviour
{
    [SerializeField] private GameObject _successCanvas;
    [SerializeField] private GameObject _nextLevelButton;
    [SerializeField] private JumpSuccessState _successState;

    private void OnEnable()
    {
        _successState.Successed += OnSuccessed;
    }

    private void OnSuccessed()
    {
        _successCanvas.SetActive(true);
        _nextLevelButton.SetActive(true);
    }

    private void OnDisable()
    {
        _successState.Successed -= OnSuccessed;
    }
}