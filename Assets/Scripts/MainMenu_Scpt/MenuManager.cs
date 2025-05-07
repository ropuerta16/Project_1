using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
     public GameObject Options_Panel;

    public void Exit_Click()
    { Application.Quit(); }

    public void Play_Click()
    { LoadScene("Tutorial"); }

    public void Option_Click()
    { Options_Panel.SetActive(true); }

    public void Back_Click()
    { Options_Panel.SetActive(false); }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
