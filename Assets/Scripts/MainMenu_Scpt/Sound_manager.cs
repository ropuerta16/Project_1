using UnityEngine;
using UnityEngine.UI;

public class Sound_manager : MonoBehaviour
{
    public Image spriterenderer;

    public Sprite newSprite;
    public Sprite oldSprite;
    private bool isUnMute;

    private void Awake()
    {
        isUnMute = true;
    }

    public void MuteClick()
    {
        if (isUnMute)
        { AudioListener.volume = 1.0f; spriterenderer.sprite = newSprite; isUnMute = false; }
        else
        { AudioListener.volume = 0.0f; spriterenderer.sprite = oldSprite; isUnMute = true; }
    }


}
