using TMPro;
using UnityEngine;

public class NotepadInteractable : Interactable
{
    [TextArea(10, 20)] [SerializeField] string pageOneText;
    [TextArea(10, 20)] [SerializeField] string pageTwoText;
    [TextArea(2, 4)] [SerializeField] string closeDialogue;
    GameObject _notePad;
    bool _open;
    TMP_Text _page1;
    TMP_Text _page2;
    AudioSource audio;
    bool read;

    public virtual void Start()
    {
        _notePad = UIManager.instance.notePadUI;
        _page1 = UIManager.instance.page1;
        _page2 = UIManager.instance.page2;
        _notePad.SetActive(false);
        audio = gameObject.GetComponent<AudioSource>();
    }

    public override void Interact()
    {
        if (_open)
        {
            _open = false;
            _notePad.SetActive(false);

            if (!read && closeDialogue != "")
            {
                UIManager.instance.SetDialogue(closeDialogue, 4f);
                read = true;
            }

            Timer.instance.UnpauseTimer();
            PlayerSingleton.main.controller.Unfreeze();
            PlayerSingleton.main.mouseLook.Unfreeze();
            PlayerSingleton.main.interact.hideIcon = false;
            return;
        }

        _notePad.SetActive(true);
        audio.Play();
        _page1.SetText(pageOneText);
        _page2.SetText(pageTwoText);

        PlayerSingleton.main.controller.Freeze();
        PlayerSingleton.main.mouseLook.Freeze();
        PlayerSingleton.main.interact.hideIcon = true;


        Timer.instance.PauseTimer();
        _open = true;
    }
}
