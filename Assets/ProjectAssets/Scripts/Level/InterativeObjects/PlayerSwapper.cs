using System;
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
                Player_1.SetActive(false);
                Player_2.SetActive(true);
                state = "G";
            }
            else if (state == "G")
            {
                Player_1.SetActive(true);
                Player_2.SetActive(false);
                state = "VP";
            }
        }
        else if (collision.gameObject.CompareTag("Player") && currentScene == "S_Level_2" )
        {
            if (state == "VP")
            {
                Player_1.SetActive(false);
                Player_2.SetActive(true);
                state = "G";
            }
            else if (state == "G")
            {
                Player_1.SetActive(false);
                Player_2.SetActive(true);
                state = "A";
            }
            else if (state == "A")
            {
                Player_1.SetActive(true);
                Player_2.SetActive(false);
                state = "VP";
            }

        }
        else if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("BulletEnemy"))
        { Destroy(collision); }
    }
}
