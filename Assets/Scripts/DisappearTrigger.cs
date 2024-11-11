using UnityEngine;

public class DisappearTrigger : MonoBehaviour
{
    [SerializeField] DisappearScript _disappearScript;
    [SerializeField] string seenDialogue;
    bool _seen;

    void OnTriggerEnter(Collider other)
    {
        if (_seen) return;
        _disappearScript.seen = true;
        DialogueManager.instance.SetDialogue(seenDialogue);
        _seen = true;
    }
}
