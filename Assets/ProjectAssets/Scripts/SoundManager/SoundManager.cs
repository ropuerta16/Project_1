using UnityEngine;
using UnityEngine.SceneManagement;
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

    public AudioSource Button_Audio;
    public AudioSource Actual_Background_Audio;
    public AudioSource GameOver_Audio;
    public AudioSource Victory_Audio;
    public AudioSource bullet_Audio;
    public AudioSource Jump_Audio;
    public AudioSource Heal_Audio;

    public GameObject FxAudio;

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
            if (MusicSlider != null && FXSlider != null)
            {
                Actual_Background_Audio.volume = MusicSlider.value;
                Button_Audio.volume = FXSlider.value;
            }
        }
    }

    public void MuteClick()
    {
        if (!isUnMute && spriteRenderer != null)
        { FxAudio.SetActive(true); Actual_Background_Audio.volume = 1.0f; spriteRenderer.sprite = newSprite; isUnMute = true; }
        else
        { FxAudio.SetActive(false); Actual_Background_Audio.volume = 0.0f; spriteRenderer.sprite = oldSprite; isUnMute = false; }
    }
}
