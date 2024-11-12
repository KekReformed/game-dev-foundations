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
    bool read;

    void Start()
    {
        _notePad = GameObject.FindGameObjectWithTag("NotepadPopup");
        _page1 = GameObject.Find("Page 1").GetComponent<TMP_Text>();
        _page2 = GameObject.Find("Page 2").GetComponent<TMP_Text>();
        _notePad.SetActive(false);
    }

    public override void Interact()
    {
        if (_open)
        {
            _open = false;
            _notePad.SetActive(false);

            if (!read && closeDialogue != "")
            {
                DialogueManager.instance.SetDialogue(closeDialogue, 4f);
                read = true;
            }

            Timer.instance.UnpauseTimer();
            PlayerSingleton.main.controller.Unfreeze();
            PlayerSingleton.main.mouseLook.Unfreeze();
            PlayerSingleton.main.interact.hideIcon = false;
            return;
        }

        _notePad.SetActive(true);

        _page1.SetText(pageOneText);
        _page2.SetText(pageTwoText);

        PlayerSingleton.main.controller.Freeze();
        PlayerSingleton.main.mouseLook.Freeze();
        PlayerSingleton.main.interact.hideIcon = true;


        Timer.instance.PauseTimer();
        _open = true;
    }
}
