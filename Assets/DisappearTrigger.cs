using UnityEngine;

public class DisappearTrigger : MonoBehaviour
{
    [SerializeField] DisappearScript _disappearScript;
    private bool seen = false;
    void OnTriggerEnter(Collider other)
    {
        if (seen) return;
        _disappearScript.seen = true;
        DialogueManager.instance.SetDialogue("Um hello?");
        seen = true;
    }
}
