using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Button_Manager : MonoBehaviour
{
    public GameObject Panel_Menu;
    public GameObject Panel_Background;

    public void Pause_Click()
    {
        Panel_Menu.SetActive(true);
        Panel_Background.SetActive(true);
        Time.timeScale = 0;
    }

    public void Exit_Click()
    {
        LoadScene("MainMenu");
    }

    public void Resume_Click()
    {
        Panel_Menu.SetActive(false);
        Panel_Background.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart_Click()
    { LoadScene("Tutorial"); }

    public void Victory_Click()
    {
        LoadScene("LoadScene(\"Level_1\");");
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
