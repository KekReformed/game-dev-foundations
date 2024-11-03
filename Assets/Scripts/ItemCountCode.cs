using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCountCode : MonoBehaviour
{
    //public string[] InvItems;
    public List<string> InvItems = new List<string>();

    public int ItemCount;

    void Start()
    {
        //InvItems = new string[6];
    }

    public void AppendToArray(string itemName)
    {
        InvItems.Add(itemName);

        //if (itemName == "Put Item Name Here")
       // {
           // ItemCount = ItemCount + 1;
           // Debug.Log(ItemCount);
       // }
    }
}
