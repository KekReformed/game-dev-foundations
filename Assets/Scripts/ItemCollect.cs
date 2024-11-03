using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollect : MonoBehaviour
{
    //public ScriptableObject ObjectDetails;
    public Item item; //Reference to scripted object 
    public GameObject playerObject; //Reference to player

    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player"); //Find the player object
    }
    private void OnTriggerStay3D(Collider3D collision) //While player is within the trigger
    {
        if (playerObject.GetComponent<PlayerController>().interact.Equals(true)) //If the player is interacting
        {
            Debug.Log(item.ItemName); //Print the name of the item
            playerObject.GetComponent<PlayerController>().SetInteractToFalse(); //Set the players interact back to false
            playerObject.GetComponent<Inventory>().AppendToArray(item.ItemName); //Add the name of the item to the inventory
            Destroy(gameObject); //Destroy the object
        }

    }
}
