using UnityEngine;

public class PlayerSwapper_scrp : MonoBehaviour
{
    public GameObject Player;
    public GameObject Player_2;

    private string state;

    private string currentScene;

    private void Awake()
    {
        LoadingManager_scrp.newScene = currentScene;

        if(currentScene == "Level_1")
            state = "VP";

        if (currentScene == "Level_2")
            state = "G";
    }




    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && currentScene == "Level_1")
        {
            if (state == "VP")
            {
                Player.SetActive(false);
                Player_2.SetActive(true);
                state = "G";
            }
            else if (state == "G")
            {
                Player.SetActive(true);
                Player_2.SetActive(false);
                state = "VP";
            }
        }
        else if (collision.gameObject.CompareTag("Player") && currentScene == "Level_2" )
        {
            if (state == "VP")
            {
                Player.SetActive(false);
                Player_2.SetActive(true);
                state = "G";
            }
            else if (state == "G")
            {
                Player.SetActive(true);
                Player_2.SetActive(false);
                state = "A";
            }
            else if (state == "A")
            {
                Player.SetActive(true);
                Player_2.SetActive(false);
                state = "VP";
            }

        }
        else if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("BulletEnemy"))
        { Destroy(collision); }
    }
}
