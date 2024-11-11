using UnityEngine;

public class DisappearScript : MonoBehaviour
{
    public bool seen;
    [SerializeField] string disappearText;

    void OnBecameInvisible()
    {
        if (seen)
        {
            gameObject.SetActive(false);
            if (disappearText != "") DialogueManager.instance.SetDialogue(disappearText);
        }
    }
}
