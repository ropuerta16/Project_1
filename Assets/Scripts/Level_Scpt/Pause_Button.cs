using UnityEngine;

public class Pause_Button : MonoBehaviour
{
   public GameObject Panel_Menu;
   public GameObject Panel_Background;

    public void OnClick ()
    {
        Panel_Menu.SetActive (true);
        Panel_Background.SetActive (true);
    }
}
