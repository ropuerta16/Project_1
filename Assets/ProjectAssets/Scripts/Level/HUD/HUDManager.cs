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
            Panel_Menu.SetActive(true);
            Pause_Button.SetActive(false);
            Time.timeScale = 0;
            ActivePanel = true;
        }
        else if (ActivePanel)
        {
            Panel_Menu.SetActive(false);
            Pause_Button.SetActive(true);
            Time.timeScale = 1;
            ActivePanel = false;
        }
    }

    public void GameOver()
    {
        SoundManager.instance.Actual_Background_Audio.Stop();
        SoundManager.instance.GameOver_Audio.Play();
        Panel_GameOver.SetActive(true);
        Pause_Button.SetActive(false);
        Time.timeScale = 0;
    }

    public void Victory()
    {
        SoundManager.instance.Actual_Background_Audio.Stop();
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
        LoadS("S_MainMenu");
        Destroy(gameObject);
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
        { LoadS("S_Tutorial"); Destroy(SoundManager.instance.gameObject); Destroy(gameObject); }
        else if (SceneManager.GetActiveScene().name == "S_Level_1")
        { LoadS("S_Level_1"); Destroy(SoundManager.instance.gameObject); Destroy(gameObject); }
        else if (SceneManager.GetActiveScene().name == "S_Level_2")
        { LoadS("S_Level_2"); Destroy(SoundManager.instance.gameObject); Destroy(gameObject); }
    }

    public void Victory_Click()
    {
        if (SceneManager.GetActiveScene().name == "S_Tutorial")
        { LoadS("S_Level_1"); Destroy(SoundManager.instance.gameObject); Destroy(gameObject); }
        else if (SceneManager.GetActiveScene().name == "S_Level_1")
        { LoadS("S_Level_2"); Destroy(SoundManager.instance.gameObject); Destroy(gameObject); }
    }

    public void Option_click()
    { Panel_Menu.SetActive(false); Panel_Options.SetActive(true); }
    public void Back_Click()
    { Panel_Options.SetActive(false); Panel_Menu.SetActive(true); }

    public void LoadS(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
