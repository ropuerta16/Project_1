using UnityEngine;
using UnityEngine.UI;

public class SoundManager_scrp : MonoBehaviour
{
    public Image spriterenderer;

    public Sprite newSprite;
    public Sprite oldSprite;
    private bool isUnMute;

    public Slider MusicSlider;
    public Slider FXSlider;

    public AudioSource MusicAudio;
    public AudioSource FXAudio;


    public static float sliderValue;

    private void Awake()
    {
        isUnMute = true;
    }
    void Update()
    {
        if (isUnMute)
        { MusicAudio.volume = MusicSlider.value; FXAudio.volume = FXSlider.value; }
        sliderValue = FXSlider.value;
        sliderValue = MusicSlider.value;
    }

    public void MuteClick()
    {
        if (!isUnMute)
        { MusicAudio.volume = 1.0f; FXAudio.volume = 1.0f; spriterenderer.sprite = newSprite; isUnMute = true; }
        else
        { MusicAudio.volume = 0.0f; FXAudio.volume = 0.0f; spriterenderer.sprite = oldSprite; isUnMute = false; }
    }
}
