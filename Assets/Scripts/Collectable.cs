using UnityEngine;

public class Collectable : Interactable
{
    [SerializeField] string objectName;
    [SerializeField] string dialogue;

    AudioSource audio;
    void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
    }
    public override void Interact()
    {
        InventoryManagerTemp.main.AddItem(objectName);
        if (dialogue != "") UIManager.instance.SetDialogue(dialogue);
        Destroy(gameObject.transform.parent.gameObject);
    }
}
