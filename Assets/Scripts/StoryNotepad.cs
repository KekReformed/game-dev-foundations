using UnityEngine;

public class StoryNotepad : NotepadInteractable
{
    [SerializeField] GameObject[] enable;
    public override void Start()
    {
        base.Start();
        for (int i = 0; i < enable.Length; i++)
        {
            GameObject storyElement = enable[i];
            storyElement.SetActive(false);
        }
    }

    public override void Interact()
    {
        base.Interact();
        for (int i = 0; i < enable.Length; i++)
        {
            GameObject storyElement = enable[i];
            storyElement.SetActive(true);
        }
    }
}
