using UnityEngine;

public class DoorInteractable : Interactable
{
    [SerializeField] bool Locked;
    [SerializeField] string key;
    Animator _animator;
    bool openState;


    void Awake()
    {
        _animator = gameObject.GetComponentInParent<Animator>();
        _animator.SetBool("Open", openState);
    }

    public override void Interact()
    {
        if (!Locked || InventoryManagerTemp.main.Keys.Contains(key))
        {
            Open();
        }
        else
        {
            UIManager.instance.SetDialogue("Looks like its locked.");
        }
    }

    public void Open()
    {
        openState = !openState;
        _animator.SetBool("Open", openState);
    }
}
