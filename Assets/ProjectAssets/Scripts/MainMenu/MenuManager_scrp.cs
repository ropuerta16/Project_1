using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager_scrp : MonoBehaviour
{
     public GameObject Options_Panel;
    public GameObject Menu_Panel;

    public AudioSource MusicAudio;

    public void Exit_Click()
    { Application.Quit(); }

    public void Play_Click()
    { LoadScene("LoadingManager"); LoadingManager_scrp.newScene = "Tutorial"; }

    public void Option_Click()
    { Options_Panel.SetActive(true); Menu_Panel.SetActive(false); }

    public void Back_Click()
    { Options_Panel.SetActive(false); Menu_Panel.SetActive(true); }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
