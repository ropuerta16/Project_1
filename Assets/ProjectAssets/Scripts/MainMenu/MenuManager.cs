using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public GameObject Panel_Options;
    public GameObject Panel_Menu;

    public void Exit_Click()
    { Application.Quit(); }

    public void Play_Click()
    { LoadScene("S_LoadingManager"); LoadingManager.instance.newScene = "S_Tutorial"; }

    public void Option_Click()
    { Panel_Options.SetActive(true); Panel_Menu.SetActive(false); }

    public void Back_Click()
    { Panel_Options.SetActive(false); Panel_Menu.SetActive(true); }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
