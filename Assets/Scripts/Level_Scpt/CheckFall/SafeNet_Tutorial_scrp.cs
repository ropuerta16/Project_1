using UnityEngine;
using UnityEngine.UIElements;

public class SafeNet_Tutorial_scrp : MonoBehaviour
{
    public Transform Player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player.transform.position = new Vector2(35f, 1.5f);
    }
}
