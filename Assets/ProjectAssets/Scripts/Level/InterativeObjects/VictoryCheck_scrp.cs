using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryCheck_scrp : MonoBehaviour
{
    public ButtonManager_scrp Manager;

    public AudioSource Victory_Audio;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Victory_Audio.Play();
        Manager.Victory();
    }
}
