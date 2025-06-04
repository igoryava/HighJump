using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    [SerializeField] private GameObject _menuCanvas;
    [SerializeField] private GameObject _settingsCanvas;
    [SerializeField] private int _maxLevels;

    private GameObject _currentPanel;

    private void Start()
    {
        Time.timeScale = 1;
        _currentPanel = _menuCanvas;
    }
    
    public void OpenClosePanel(GameObject panel)
    {
        _currentPanel.SetActive(false);
        panel.SetActive(true);
        _currentPanel = panel;
        if (_settingsCanvas.activeSelf)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
    
    public void OnSoundVolumeChanged(SoundVolumeSettings soundVolumeSettings)
    {
        soundVolumeSettings.ChangeSoundVolume();
    }
    
    public void OnVibrationStrengthChanged(VibrationSettings vibrationSettings)
    {
        vibrationSettings.ChangeVibrationStrength();
    }
    
    public void Exit()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    
    public void MiniGame()
    {
        SceneManager.LoadScene("Menu");
    }
    
    public void Play()
    {
        int level = PlayerPrefs.GetInt("CompleatedLevels", 1);


        Debug.Log(level);
        if (level == 1)
        {
            SceneManager.LoadScene("Game");
        }
        else
        {
            if (level >= _maxLevels)
            {
                PlayerPrefs.SetInt("CurrentLevel", 1);
                SceneManager.LoadScene("Game");
                return;
            }

            PlayerPrefs.SetInt("CurrentLevel", level);
            SceneManager.LoadScene("Game");
        }
    }
}
