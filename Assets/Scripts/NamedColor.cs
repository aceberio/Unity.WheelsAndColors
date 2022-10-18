using System;
using UnityEngine;

[Serializable]
public struct NamedColor
{
    [field: SerializeField] public string Name { get; set; }
    [field: SerializeField] public Color Color { get; set; }
}