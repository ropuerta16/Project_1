using UnityEngine;

public class Pause_Button : MonoBehaviour
{
   GameObject PanelMenu;

    public void OnClick ()
    {
        PanelMenu.SetActive (true);
    }
}
