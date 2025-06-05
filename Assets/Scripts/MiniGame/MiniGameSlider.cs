using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UniRx;
using UnityEngine;

public class MiniGameSlider : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _magitude;
    [SerializeField] private GameObject _grade;
    private Vector3 _startPosition;
    private CompositeDisposable _disposable = new CompositeDisposable();
    private void Start()
    {
        _startPosition = transform.position;
        MoveSlider();
    }

    public void StopSlider()
    {
        _disposable.Clear();
        StartCoroutine(ShowGrade());
    }

    private IEnumerator ShowGrade()
    {
        _grade.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        _grade.SetActive(false);
        MoveSlider();
    }

    private void MoveSlider()
    {
        Observable.EveryUpdate().Subscribe(_ =>
        {
            transform.position = _startPosition + transform.right * Mathf.Sin(Time.time * _speed) * _magitude;
        }).AddTo(_disposable);
    }

    private void OnDisable()
    {
        _disposable.Clear();
    }
}
