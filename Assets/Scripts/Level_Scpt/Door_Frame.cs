using UnityEngine;
using UnityEngine.SceneManagement;

public class Door_Frame : MonoBehaviour
{
    public GameObject Victory_Panel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Victory_Panel.SetActive(true);
    }
}
