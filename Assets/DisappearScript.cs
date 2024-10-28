using UnityEngine;

public class DisappearScript : MonoBehaviour
{
    public bool seen;

    void OnBecameInvisible()
    {
        if (seen)
        {
            gameObject.SetActive(false);
            DialogueManager.instance.SetDialogue("I wonder if that guy outside could help me");
        }
    }
}
