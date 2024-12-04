using UnityEngine;

public class KeyInteractable : Interactable
{
    [SerializeField] string keyName;
    public override void Interact()
    {
        InventoryManagerTemp.main.AddItem(keyName);
        UIManager.instance.SetDialogue($"You got the {keyName} key!");
        Destroy(gameObject);
    }
}
