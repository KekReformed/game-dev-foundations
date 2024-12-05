using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] GameObject dialogueObject;
    public GameObject notePadUI;
    public TMP_Text page1;
    public TMP_Text page2;
    float _dialogueTimeMax;
    float _dialogueTimer;
    bool _displaying;
    readonly Color himColor = Color.cyan;
    readonly Color playerColor = Color.white;
    TMP_Text text;


    void Awake()
    {
        if (instance == null)
        {
            instance = gameObject.GetComponent<UIManager>();
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

    public void SetDialogue(string dialogue, float time = 2f, bool player = true)
    {
        text.SetText(dialogue);
        dialogueObject.SetActive(true);

        _dialogueTimer = 0f;
        _dialogueTimeMax = time;
        _displaying = true;

        if (player)
        {
            text.color = playerColor;
        }
        else
        {
            text.color = himColor;
        }
    }
}
