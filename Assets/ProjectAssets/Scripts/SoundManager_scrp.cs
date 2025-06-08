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

    public AudioSource ButtonAudio;
    public AudioSource BackgroundAudio;

    public GameObject FxAudio;

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
            BackgroundAudio.volume = MusicSlider.value;
            ButtonAudio.volume = FXSlider.value;
        }
        MusicSliderValue = MusicSlider.value;
        FXSliderValue = FXSlider.value;
    }

    public void MuteClick()
    {
        if (!isUnMute)
        { FxAudio.SetActive(true); BackgroundAudio.volume = 1.0f; spriterenderer.sprite = newSprite; isUnMute = true; }
        else
        { FxAudio.SetActive(false); BackgroundAudio.volume = 0.0f;   spriterenderer.sprite = oldSprite; isUnMute = false; }
    }
}
