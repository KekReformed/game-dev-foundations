using UnityEngine;

public class MemplayerInteractable : Interactable
{
    public GameObject bodyParts;
    public Camera endCamera;
    public Canvas canvas;
    public DialogueChain endDialogue;
    public override void Interact()
    {
        UIManager.instance.SetDialogue("I need to find the rest of the body parts");
        if (!InventoryManagerTemp.main.Keys.Contains("Head")) return;
        if (!InventoryManagerTemp.main.Keys.Contains("Torso")) return;
        if (!InventoryManagerTemp.main.Keys.Contains("Legs")) return;
        if (!InventoryManagerTemp.main.Keys.Contains("Arms")) return;
        bodyParts.SetActive(true);
        endCamera.enabled = true;
        canvas.worldCamera = endCamera;
        PlayerSingleton.main.interact.hideIcon = true;
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        endDialogue.start = true;
    }
}
