using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBar : MonoBehaviour
{
    public event Action Start;
    public event Action Released;

    public void StartHold()
    {
        Start?.Invoke();
    }

    public void Release()
    {
        Released?.Invoke();
    }
}