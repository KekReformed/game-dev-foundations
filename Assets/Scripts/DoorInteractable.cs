using UnityEngine;

public class DoorInteractable : Interactable
{
    [SerializeField] bool Locked;
    [SerializeField] string key;
    Animator _animator;
    AudioSource audio;
    bool openState;


    void Awake()
    {
        _animator = gameObject.GetComponentInParent<Animator>();
        _animator.SetBool("Open", openState);
        audio = gameObject.GetComponentInParent<AudioSource>();
    }

    public override void Interact()
    {
        if (!Locked || InventoryManagerTemp.main.Keys.Contains(key))
        {
            Open();
            audio.Play();
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
