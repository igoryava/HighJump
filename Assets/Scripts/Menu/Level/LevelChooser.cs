using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelChooser : MonoBehaviour
{
    [SerializeField] private GameObject _block;
    [SerializeField] private GameObject _unblock;

    [SerializeField] private TextMeshProUGUI _heightText;

    [SerializeField] private Level _level;

    private Button _button;


    private void Awake()
    {
        _button = GetComponent<Button>();
        Debug.Log(PlayerPrefs.GetInt("CompleatedLevels", 1));

        if (PlayerPrefs.GetInt("CompleatedLevels", 1) + 1 >= _level.Number)
        {
            _heightText.text = _level.Height.ToString();

            _button.onClick.AddListener(Clicked);
            return;
        }

        Lock();
    }

    private void Clicked()
    {
        PlayerPrefs.SetInt("CurrentLevel", _level.Number);

        SceneManager.LoadScene("Game");
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Clicked);
    }

    private void Lock()
    {
        _unblock.SetActive(false);
        _block.SetActive(true);
    }
}