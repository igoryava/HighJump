using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject _panelToSwitch;
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private GameObject _mainPanel;
    [SerializeField] private float _coolDown;

    public void Switch()
    {
        _mainPanel.SetActive(false);
        _panelToSwitch.SetActive(true);
        StartCoroutine(OnPanelSwitched());
    }

    private IEnumerator OnPanelSwitched()
    {
        yield return new WaitForSeconds(_coolDown);
        transform.gameObject.SetActive(false);
        _menuPanel.SetActive(true);
    }
}
