using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }


    public Image spriteRenderer;

    public Sprite newSprite;
    public Sprite oldSprite;
    private bool isUnMute;

    public Slider FXSlider;
    public Slider MusicSlider;

    public AudioSource ButtonAudio;
    public AudioSource BackgroundAudio;
    public AudioSource GameOver_Audio;
    public AudioSource Victory_Audio;
    public AudioSource bullet_Audio;
    public AudioSource Jump_Audio;
    public AudioSource Heal_Audio;

    public GameObject FxAudio;

    public float FXSliderValue;
    public float MusicSliderValue;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
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
        { FxAudio.SetActive(true); BackgroundAudio.volume = 1.0f; spriteRenderer.sprite = newSprite; isUnMute = true; }
        else
        { FxAudio.SetActive(false); BackgroundAudio.volume = 0.0f; spriteRenderer.sprite = oldSprite; isUnMute = false; }
    }
}
