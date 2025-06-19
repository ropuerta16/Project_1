using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class HUDManager : MonoBehaviour
{
    public static HUDManager instance {  get; private set; }

    public GameObject Panel_Menu;
    public GameObject Panel_Options;
    public GameObject Pause_Button;
    public GameObject Panel_Victory;
    public GameObject Panel_Reloading;
    public GameObject Panel_GameOver;

    public TMP_Text counter;

    private bool ActivePanel;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        ActivePanel = false;
        Time.timeScale = 1;
    }

    public void Esc(InputAction.CallbackContext context)
    {
        if (!ActivePanel)
        {
            HUDManager.instance.Panel_Menu.SetActive(true);
            Time.timeScale = 0;
            ActivePanel = true;
        }
        else if (ActivePanel)
        {
            HUDManager.instance.Panel_Menu.SetActive(false);
            Time.timeScale = 1;
            ActivePanel = false;
        }
    }

    public void GameOver()
    {
        SoundManager.instance.BackgroundAudio.Stop();
        SoundManager.instance.GameOver_Audio.Play();
        Panel_GameOver.SetActive(true);
        Pause_Button.SetActive(false);
        Time.timeScale = 0;
    }

    public void Victory()
    {
        SoundManager.instance.BackgroundAudio.Stop();
        SoundManager.instance.Victory_Audio.Play();
        Panel_Victory.SetActive(true);
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
        LoadScene("S_MainMenu");
    }

    public void Resume_Click()
    {
        Panel_Menu.SetActive(false);
        Pause_Button.SetActive(true);
        Time.timeScale = 1;
    }

    public void Restart_Click()
    {
        if (SceneManager.GetActiveScene().name == "S_Tutorial")
        { LoadScene("S_Tutorial"); }
        else if (SceneManager.GetActiveScene().name == "S_Level_1")
        { LoadScene("S_Level_1"); }
        else if (SceneManager.GetActiveScene().name == "S_Level_2")
        { LoadScene("S_Level_2"); }
    }

    public void Victory_Click()
    {
        if (SceneManager.GetActiveScene().name == "S_Tutorial")
        { LoadScene("S_Level_1"); }
        else if (SceneManager.GetActiveScene().name == "S_Level_1")
        { LoadScene("S_Level_2"); }
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
