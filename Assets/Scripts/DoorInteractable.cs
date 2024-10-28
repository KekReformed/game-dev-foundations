using UnityEngine;

public class DoorInteractable : Interactable
{
    Animator _animator;
    bool openState;

    void Awake()
    {
        _animator = gameObject.GetComponentInParent<Animator>();
        _animator.SetBool("Open", openState);
    }

    public override void Interact()
    {
        Open();
    }

    public void Open()
    {
        openState = !openState;
        _animator.SetBool("Open", openState);
    }
}
