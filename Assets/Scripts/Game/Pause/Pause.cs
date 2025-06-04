using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject _pauseCanvas;

    public void BeginPause()
    {
        Time.timeScale = 0;
        _pauseCanvas.SetActive(true);
    }

    public void UnPause()
    {
        Time.timeScale = 1;
        _pauseCanvas.SetActive(false);
    }

    public void Menu()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene("Menu");
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }
}