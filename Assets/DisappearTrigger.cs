using UnityEngine;

public class DisappearTrigger : MonoBehaviour
{
    [SerializeField] DisappearScript _disappearScript;
    void OnTriggerEnter(Collider other)
    {
        _disappearScript.seen = true;
        DialogueManager.instance.SetDialogue("Um hello?");
    }
}
