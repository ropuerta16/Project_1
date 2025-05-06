using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu_Button : MonoBehaviour
{
    public GameObject Exit_Button;
    public GameObject Resume_Button;
    public GameObject Panel_Menu;
    public GameObject Panel_Background;

    public void Exit_Click()
    {
        SceneManager.LoadScene(0);
        //Application.Quit();
    }

    public void Resume_Click()
    {
        Panel_Menu.SetActive(false);
        Panel_Background.SetActive(true);
    }
}
