using UnityEngine;

public class Sound_manager : MonoBehaviour
{
    public SpriteRenderer spriterenderer;
    public Sprite newSprite;
    public Sprite oldSprite;
    private bool isUnMute;

    private void Awake()
    {
        isUnMute = true;
    }
    private void MuteClick()
    {
        if (isUnMute)
        { AudioListener.volume = 1.0f; spriterenderer.sprite = newSprite; isUnMute = false; }
        else
        { AudioListener.volume = 0.0f; spriterenderer.sprite = oldSprite; isUnMute = true; }
    }
}
