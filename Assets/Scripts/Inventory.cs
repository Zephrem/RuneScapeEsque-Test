using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }

        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged OnItemChangedCallback;

    public List<Item> items = new List<Item>();

    public int space = 24;

    public void AddItem(Item item)
    {
        if(items.Count >= space)
        {
            Debug.Log("Bags full.");
            return;
        }

        items.Add(item);
        OnItemChangedCallback?.Invoke();
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
        OnItemChangedCallback?.Invoke();
    }
}
