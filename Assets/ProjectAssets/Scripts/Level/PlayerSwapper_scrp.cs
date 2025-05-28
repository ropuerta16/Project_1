using UnityEngine;

public class PlayerSwapper_scrp : MonoBehaviour
{
    public GameObject Player;
    public GameObject Player_2;

    private string state;

    private void Awake()
    {
        state = "VP";
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(state == "VP")
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
        else if (state == "A")
        { }
    }
}
