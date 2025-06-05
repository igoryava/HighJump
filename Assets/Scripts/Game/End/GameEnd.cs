using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    [SerializeField] private JumpSuccessState _successState;

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnEnable()
    {
        _successState.Successed += OnSuccess;
    }

    private void OnSuccess()
    {
        PlayerPrefs.SetInt("CompleatedLevels", PlayerPrefs.GetInt("CurrentLevel", 1));
    }

    private void OnDisable()
    {
        _successState.Successed -= OnSuccess;
    }

    public void NextLevel()
    {
        if (PlayerPrefs.GetInt("CurrentLevel", 1) >= 10)
            PlayerPrefs.SetInt("CurrentLevel", 1);
        else
            PlayerPrefs.SetInt("CurrentLevel", PlayerPrefs.GetInt("CurrentLevel", 1) + 1);


        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}