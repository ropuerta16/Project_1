using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryCkeck_scrp : MonoBehaviour
{
    public ButtonManager_scrp Manager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Manager.Victory();
    }
}
