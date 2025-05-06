using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject Exit_Button;
    public GameObject Play_Button;

    public void Exit_Click()
    { Application.Quit(); }

    public void Play_Click()
    { SceneManager.LoadScene(2); }
}
