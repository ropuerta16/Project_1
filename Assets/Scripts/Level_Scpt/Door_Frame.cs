using UnityEngine;
using UnityEngine.SceneManagement;

public class Door_Frame : MonoBehaviour
{
    public Button_Manager Manager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Manager.Victory();
    }
}
