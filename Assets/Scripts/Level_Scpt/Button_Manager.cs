using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Button_Manager : MonoBehaviour
{
    public GameObject Panel_Menu;
    public GameObject Panel_Options;
    public GameObject Pause_Button;
    public GameObject Victory_Panel;

    public PlayerMovement Player;
    public GameObject Panel_GameOver;

    private void Update()
    {
        if (Player.Health <= 0)
        {
            GamneOver();
        }
    }

    public void GamneOver()
    {
        Panel_GameOver.SetActive(true);
        Pause_Button.SetActive(false);
        Time.timeScale = 0;
    }

    public void Victory()
    {
        Victory_Panel.SetActive(true);
        Pause_Button.SetActive(false);
        Time.timeScale = 0;
    }

    public void Pause_Click()
    {
        Panel_Menu.SetActive(true);
        Pause_Button.SetActive(false);
        Time.timeScale = 0;
    }

    public void Exit_Click()
    {
        LoadScene("MainMenu");
    }

    public void Resume_Click()
    {
        Panel_Menu.SetActive(false);
        Pause_Button.SetActive(true);
        Time.timeScale = 1;
    }

    public void Restart_Click()
    { LoadScene("Tutorial"); Time.timeScale = 1; }

    public void Victory_Click()
    {
        //("LoadScene("Level_1");
        LoadScene("MainMenu");
    }

    public void Option_click()
    { Panel_Menu.SetActive(false); Panel_Options.SetActive(true); }
    public void Back_Click()
    { Panel_Options.SetActive(false); Panel_Menu.SetActive(true); }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
