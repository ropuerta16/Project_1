using UnityEngine;

public class PotionManager : MonoBehaviour
{
    public PlayerManager player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            HealDamage(30);
            SoundManager.instance.Heal_Audio.Play();

            Destroy(gameObject);
        }
    }

    private void HealDamage(int heal)
    {
        player.Health += heal;

        if (player.Health > player.MaxHealth)
        {
            player.Health = player.MaxHealth;
        }

        player.healthSlider.value = player.Health;

    }
}
