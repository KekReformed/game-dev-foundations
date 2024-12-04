using System.Collections.Generic;
using UnityEngine;

public class InventoryManagerTemp : MonoBehaviour
{
    public static InventoryManagerTemp main;
    public HashSet<string> Keys = new HashSet<string>();

    void Awake()
    {
        if (main == null)
        {
            main = gameObject.GetComponent<InventoryManagerTemp>();
        }
    }

    public void AddItem(string item)
    {
        Keys.Add(item);
    }

    public void RemoveItem(string item)
    {
        Keys.Remove(item);
    }
}
