using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UI_SettingPanel : MonoBehaviour
{
    [Header("Mixer")]
    [SerializeField] private AudioMixer _audioMixer;

    [Header("UI")]
    [SerializeField] private Slider _bgmSlider;
    [SerializeField] private Slider _sfxSlider;

    private void Awake() 
    {
        if (!PlayerPrefs.HasKey("BGM"))
        {        
            PlayerPrefs.SetFloat("BGM", 1); //차후 JSON으로 변경
            PlayerPrefs.SetFloat("SFX", 1); //차후 JSON으로 변경
        }

        _bgmSlider.value = Mathf.Log10(PlayerPrefs.GetFloat("BGM")) * 20; //차후 JSON으로 변경
        _sfxSlider.value = Mathf.Log10(PlayerPrefs.GetFloat("SFX")) * 20; //차후 JSON으로 변경

    }

    private void OnEnable() 
    {
        _bgmSlider.value = PlayerPrefs.GetFloat("BGM"); //차후 JSON으로 변경
        _sfxSlider.value = PlayerPrefs.GetFloat("SFX"); //차후 JSON으로 변경
    }

    public void SetBGM(float value)
    {
        _audioMixer.SetFloat("BGM", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("BGM", value); //차후 JSON으로 변경
    }

    public void SFXBGM(float value)
    {
        _audioMixer.SetFloat("SFX", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("SFX", value); //차후 JSON으로 변경
    }
}
