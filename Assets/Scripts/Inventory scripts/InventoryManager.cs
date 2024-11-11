using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Dictionary<string,ItemData> InventoryDictionary = new Dictionary<string, ItemData>();

    public ItemData[] items;
    
    // Start is called before the first frame update
    void Start()    
    {
        for (int i = 0; i < InventoryDictionary.Count; i++)
        {
            ItemData item = items[i];
            
            InventoryDictionary.Add(item.id, item);     

            Debug.Log(item.itemName); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        var id = InventoryDictionary["DoorKey"];

        //Debug.Log(id.itemName);

        foreach (KeyValuePair<string, ItemData> i in InventoryDictionary)
        {
            //do something with entry.Value or entry.Key

        }
    }

    
}
