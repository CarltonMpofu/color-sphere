using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Orb Color", fileName = "New Orb Color")]
public class OrbColorSO : ScriptableObject
{
    [SerializeField] int colorID;
    [SerializeField] Color orbColor;

    [SerializeField] string colorName;

    public int GetColorID()
    {
        return colorID;
    }

    public Color GetColor()
    {
        return orbColor;
    }

    public string GetColorName()
    {
        return colorName;
    }
}
