using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField] private float baseValue;
    [SerializeField] private List<float> mods = new List<float>();

    public float GetValue()
    {
        float totalValue = baseValue;

        mods.ForEach(x => totalValue += x);

        return (totalValue);
    }

    public void AddMod(float x)
    {
        mods.Add(x);
    }

    public void RemoveMod(float x)
    {
        mods.Remove(x);
    }
}
