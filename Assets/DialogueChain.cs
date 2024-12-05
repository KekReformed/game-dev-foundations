using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueChain : MonoBehaviour
{
    [SerializeField] string[] dialogueList;
    public bool start;
    public GameObject endScreen;
    float timer;


    // Update is called once per frame
    void Update()
    {
        if (!start) return;
        timer += Time.deltaTime;
        if (timer < 4 && timer > 0) UIManager.instance.SetDialogue(dialogueList[0], .1f, false);
        if (timer < 8 && timer > 4) UIManager.instance.SetDialogue(dialogueList[1], .1f, false);
        if (timer < 12 && timer > 8) UIManager.instance.SetDialogue(dialogueList[2], .1f, false);
        if (timer < 16 && timer > 12) UIManager.instance.SetDialogue(dialogueList[3], .1f, false);
        if (timer > 20)
        {
            Cursor.lockState = CursorLockMode.None;
            endScreen.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F)) SceneManager.LoadScene(0);
            Timer.instance.currentTime = 99999f;
        }
    }
}
