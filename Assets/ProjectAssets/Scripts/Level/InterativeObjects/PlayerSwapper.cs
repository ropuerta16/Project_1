using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSwapper : MonoBehaviour
{
    public GameObject Player_1;
    public GameObject Player_2;

    private string state;

    private string currentScene;

    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene().name;

        if (SceneManager.GetActiveScene().name == "S_Level_1")
            state = "VP";

        if (SceneManager.GetActiveScene().name == "S_Level_2")
            state = "G";
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && currentScene == "S_Level_1")
        {
            if (state == "VP")
            {
                ChangePlayer(true);
                state = "G";
            }
            else if (state == "G")
            {
                ChangePlayer(false);
                state = "VP";
            }
        }
        else if (collision.gameObject.CompareTag("Player") && currentScene == "S_Level_2" )
        {
            if (state == "VP")
            {
                ChangePlayer(true);
                state = "G";
            }
            else if (state == "G")
            {
                ChangePlayer(true);
                state = "A";
            }
            else if (state == "A")
            {
                ChangePlayer(false);
                state = "VP";
            }

        }
        else if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("BulletEnemy"))
        { Destroy(collision); }
    }

    private void ChangePlayer(bool active)
    {
        Player_1.SetActive(!active);
        Player_2.SetActive(active);
    }
}
