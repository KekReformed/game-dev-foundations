using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public ItemData[] items;
    public Dictionary<string, ItemData> InventoryDictionary;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < InventoryDictionary.Count; i++)
        {
            ItemData item = items[i];

            InventoryDictionary.Add(item.id, item);

        }
    }

    // Update is called once per frame
    void Update()
    {
        ItemData idk = InventoryDictionary["DoorKey"];
        ItemData eh = InventoryDictionary["DoorKey"];
    }
}
