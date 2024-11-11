using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    [SerializeField] GameObject dialogueObject;
    float _dialogueTimeMax;
    float _dialogueTimer;
    bool _displaying;
    TMP_Text text;


    void Awake()
    {
        if (instance == null)
        {
            instance = gameObject.GetComponent<DialogueManager>();
        }

        text = dialogueObject.GetComponent<TMP_Text>();
        dialogueObject.SetActive(false);
        SetDialogue("Where am I? the last thing I remember is getting into a machine and now I'm... here", 5f);
    }

    void Update()
    {
        if (_displaying)
        {
            _dialogueTimer += Time.deltaTime;
            if (_dialogueTimer > _dialogueTimeMax)
            {
                _displaying = false;
                dialogueObject.SetActive(false);
            }
        }
    }

    public void SetDialogue(string dialogue, float time = 2f)
    {
        text.SetText(dialogue);
        dialogueObject.SetActive(true);

        _dialogueTimer = 0f;
        _dialogueTimeMax = time;
        _displaying = true;
    }
}
