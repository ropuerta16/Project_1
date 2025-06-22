using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public GameObject Panel_Options;
    public GameObject Panel_Menu;
    private LoadingManager LoadingManager;

    public void Exit_Click()
    { Application.Quit(); }

    public void Play_Click()
    { Destroy(SoundManager.instance.gameObject); LoadS("S_LoadingManager"); LoadingManager.newScene = "S_Tutorial";  }

    public void Option_Click()
    { Panel_Options.SetActive(true); Panel_Menu.SetActive(false); }

    public void Back_Click()
    { Panel_Options.SetActive(false); Panel_Menu.SetActive(true); }

    public void LoadS(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
