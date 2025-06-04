using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _topLevelText;
    [SerializeField] private TextMeshProUGUI _topHeightText;
    [SerializeField] private TextMeshProUGUI _rate;

    private void Start()
    {
        _topLevelText.text = PlayerPrefs.GetInt("TopLevel", 1).ToString();
        _topHeightText.text = PlayerPrefs.GetFloat("TopHeight", 1).ToString();

        float wins = PlayerPrefs.GetInt("Wins", 1);
        float loses = PlayerPrefs.GetInt("Loses", 1);

        float rate = wins / (loses + wins) * 100;

        Debug.Log("Loses " + PlayerPrefs.GetInt("Loses", 1));
        Debug.Log("Wins " + PlayerPrefs.GetInt("Wins", 1));

        Debug.Log(rate + "%");
        _rate.text = rate + "%";
    }
}