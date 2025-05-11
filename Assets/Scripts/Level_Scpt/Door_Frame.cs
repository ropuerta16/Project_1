using UnityEngine;
using UnityEngine.SceneManagement;

public class Door_Frame : MonoBehaviour
{
    public GameObject Victory_Panel;
    public GameObject Pause_Button;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Victory_Panel.SetActive(true);
        Pause_Button.SetActive(false);
        Time.timeScale = 0;
    }
}
