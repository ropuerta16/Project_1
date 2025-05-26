using UnityEngine;
using UnityEngine.UI;

public class Sound_manager : MonoBehaviour
{
    public Image spriterenderer;

    public Sprite newSprite;
    public Sprite oldSprite;
    private bool isUnMute;

    public Slider sliderVolume;
    public AudioSource BackgroundAudio;

    public static float sliderValue;

    private void Awake()
    {
        isUnMute = true;
    }
    void Update()
    {
        if (isUnMute)
        { BackgroundAudio.volume = sliderVolume.value; }
        sliderValue = sliderVolume.value;
    }

    public void MuteClick()
    {
        if (!isUnMute)
        { BackgroundAudio.volume = 1.0f; spriterenderer.sprite = newSprite; isUnMute = true; }
        else
        { BackgroundAudio.volume = 0.0f; spriterenderer.sprite = oldSprite; isUnMute = false; }
    }
}
