using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ButtonManager_scrp : MonoBehaviour
{
    public GameObject Panel_Menu;
    public GameObject Panel_Options;
    public GameObject Pause_Button;
    public GameObject Victory_Panel;

    public GameObject Panel_GameOver;

    public AudioSource Background_Audio;
    public AudioSource GameOver_Audio;
    public AudioSource Victory_Audio;


    private void Awake()
    {
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        Background_Audio.Stop();
        GameOver_Audio.Play();
        Panel_GameOver.SetActive(true);
        Pause_Button.SetActive(false);
        Time.timeScale = 0;
    }

    public void Victory()
    {
        Background_Audio.Stop();
        Victory_Audio.Play();
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
    {
        if (SceneManager.GetActiveScene().name == "Tutorial")
        { LoadScene("Tutorial"); }
        else if (SceneManager.GetActiveScene().name == "Level_1")
        { LoadScene("Level_1"); }
        else if(SceneManager.GetActiveScene().name == "Level_2")
        { LoadScene("Level_2"); }
    }

    public void Victory_Click()
    {
        if (SceneManager.GetActiveScene().name == "Tutorial")
        { LoadScene("Level_1"); }
        else if (SceneManager.GetActiveScene().name == "Level_1")
        { LoadScene("Level_2"); }
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
