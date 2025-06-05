using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject _panelToSwitch;
    [SerializeField] private GameObject _mainPanel;

    public void Switch()
    {
        _mainPanel.SetActive(false);
        _panelToSwitch.SetActive(true);
    }

    public void SwitchBack()
    {
        _panelToSwitch.SetActive(false);
        _mainPanel.SetActive(true);
    }
}
