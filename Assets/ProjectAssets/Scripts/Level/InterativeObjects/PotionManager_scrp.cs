using UnityEngine;

public class PotionManager_scrp : MonoBehaviour
{
    public PlayerManager_Scrp player;

    public AudioSource Heal_Audio;

    private void Awake()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.Health += 30;

        if (player.Health > 100)
        { 
            player.Health = 100;
        }

        player.healthSlider.value = player.Health;

        Heal_Audio.Play();

        Destroy(gameObject);
    }
}
