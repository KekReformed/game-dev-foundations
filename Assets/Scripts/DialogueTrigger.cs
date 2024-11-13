using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] bool canTriggerMultipleTimes;
    [SerializeField] string _dialogue;
    bool _dialogueTriggered;

    void OnTriggerEnter(Collider other)
    {
        if (!_dialogueTriggered || canTriggerMultipleTimes)
        {
            UIManager.instance.SetDialogue(_dialogue);
            _dialogueTriggered = true;
        }
    }
}
