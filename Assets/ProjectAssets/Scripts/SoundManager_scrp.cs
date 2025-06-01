using UnityEngine;
using UnityEngine.UI;

public class SoundManager_scrp : MonoBehaviour
{
    public Image spriterenderer;

    public Sprite newSprite;
    public Sprite oldSprite;
    private bool isUnMute;

    public Slider FXSlider;
    public Slider MusicSlider;

    public AudioSource FXAudio;
    public AudioSource MusicAudio;

    public static float FXSliderValue;
    public static float MusicSliderValue;

    private void Awake()
    {
        isUnMute = true;
    }
    void Update()
    {
        if (isUnMute)
        { 
            MusicAudio.volume = MusicSlider.value;
            FXAudio.volume = FXSlider.value;
        }
        MusicSliderValue = MusicSlider.value;
        FXSliderValue = FXSlider.value;
    }

    public void MuteClick()
    {
        if (!isUnMute)
        { MusicAudio.volume = 1.0f; FXAudio.volume = 1.0f; spriterenderer.sprite = newSprite; isUnMute = true; }
        else
        { MusicAudio.volume = 0.0f; FXAudio.volume = 0.0f; spriterenderer.sprite = oldSprite; isUnMute = false; }
    }
}
