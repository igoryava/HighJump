using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Level")]
public class Level : ScriptableObject
{
    [field: SerializeField] public int Number { get; private set; }
    [field: SerializeField] public float Height { get; private set; }
}