using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class Settings : MonoBehaviour
{
    [Header("Button Sound On\\Off")]
    public ButtonSoundOnOff buttonSoundOnOff;

    [Header(" Settings slider")]
    public AudioSettingsUI audioSettingsUI;

    private void Start()
    {
        buttonSoundOnOff.Init();
        audioSettingsUI.Init();
        // buttonSoundSettings.Init();
        // sliderSettings.Init();
    }
}

[System.Serializable]
public class ButtonSoundOnOff // Settings button
{
    [SerializeField] private Image buttonSoundOnOffImageIcon;
    private string offIconAddress = "Assets/Art/UI/White Sound Off.png";

    private Sprite onSprite;
    private Sprite offSprite;
    private bool isOff = false;

    public void Init()
    {
        onSprite = buttonSoundOnOffImageIcon.sprite;
        Addressables.LoadAssetAsync<Sprite>(offIconAddress).Completed += OnOffSpriteLoaded; //Load off sprite

        Button soundButton = buttonSoundOnOffImageIcon.GetComponentInChildren<Button>();
        //Button soundButton = buttonSoundOnOffImageIcon.GetComponentInParent<Button>();
        soundButton.onClick.AddListener(ToggleIcon);
    }
    // void Start()
    // {
    //     onSprite = buttonSoundOnOffImageIcon.sprite;
    //     Addressables.LoadAssetAsync<Sprite>(offIconAddress).Completed += OnOffSpriteLoaded; //Load off sprite
    //     //Button soundButton = 
    //     Button soundButton = GetComponentInChildren<Button>();
    //     soundButton.onClick.AddListener(ToggleIcon);
    // }

    private void OnOffSpriteLoaded(AsyncOperationHandle<Sprite> handle)
    {
        offSprite = handle.Result;
    }

    public void ToggleIcon()
    {
        isOff = !isOff;
        buttonSoundOnOffImageIcon.sprite = isOff ? offSprite : onSprite;

        AudioManager.Instance.SetMusicVolume(isOff ? 0f : PlayerPrefs.GetFloat("MusicVolume", 1f));
        AudioManager.Instance.SetSFXVolume(isOff ? 0f : PlayerPrefs.GetFloat("SFXVolume", 1f));//future use
    }
}

[System.Serializable]
public class AudioSettingsUI // Settings slider
{
    public Slider musicSlider;
    //public Slider sfxSlider;

    public void Init()
    {
        // Loadn save value
        float musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        float sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);

        musicSlider.value = musicVolume;

        AudioManager.Instance.SetMusicVolume(musicVolume);

        musicSlider.onValueChanged.AddListener(OnMusicSliderChanged);
    }


    private void OnMusicSliderChanged(float value)
    {
        AudioManager.Instance.SetMusicVolume(value);
        PlayerPrefs.SetFloat("MusicVolume", value);
    }

    private void OnSFXSliderChanged(float value) // future use
    {
        AudioManager.Instance.SetSFXVolume(value);
        PlayerPrefs.SetFloat("SFXVolume", value);
    }
}