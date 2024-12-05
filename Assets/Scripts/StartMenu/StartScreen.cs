using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public Camera StartCamera;
    public Camera OptionsCamera;
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Options()
    {

    }
    public void BackOptions()
    {
        Application.OpenURL("https://forms.gle/xKTHp8NQBYn4YHBM6");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
