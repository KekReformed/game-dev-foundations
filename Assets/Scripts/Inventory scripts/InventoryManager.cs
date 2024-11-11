using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Dictionary<string,ItemData> InventoryDictionary;

    public ItemData[] items;
    
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
        var idk = InventoryDictionary["DoorKey"];
        InventoryDictionary["DoorKey"];
    }
}
