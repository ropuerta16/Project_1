using UnityEngine;

public class PotionManager : MonoBehaviour
{
    public PlayerManager player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.Health += 30;

        if (player.Health > 100)
        { 
            player.Health = 100;
        }

        player.healthSlider.value = player.Health;

        SoundManager.instance.Heal_Audio.Play();

        Destroy(gameObject);
    }
}
