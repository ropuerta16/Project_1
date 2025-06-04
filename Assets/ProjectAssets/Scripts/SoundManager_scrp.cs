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
    public AudioSource MusicAudio;

    public GameObject Audio;

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
            ButtonAudio.volume = FXSlider.value;
        }
        MusicSliderValue = MusicSlider.value;
        FXSliderValue = FXSlider.value;
    }

    public void MuteClick()
    {
        if (!isUnMute)
        { Audio.SetActive(true); spriterenderer.sprite = newSprite; isUnMute = true; }
        else
        { Audio.SetActive(false); spriterenderer.sprite = oldSprite; isUnMute = false; }
    }
}
