using UnityEngine;
using UnityEngine.UI;

public class AudioSettingsUI : MonoBehaviour
{
    public GameObject panel;
    public Slider bgmSlider;
    public Slider seSlider;

    private bool isOpen = false;

    void Start()
    {
        panel.SetActive(false); // 初期非表示

        bgmSlider.onValueChanged.AddListener(OnBGMVolumeChanged);
        seSlider.onValueChanged.AddListener(OnSEVolumeChanged);

        // 初期値をAudioManagerから取得（必要なら保存データから）
        bgmSlider.value = AudioManager.Instance.bgmSource.volume;
        if (AudioManager.Instance.seSources.Length > 0)
            seSlider.value = AudioManager.Instance.seSources[0].volume;
    }

    void Update()
    {
        //escキーで音量調整画面を表示
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isOpen = !isOpen;
            panel.SetActive(isOpen);
        }
    }

    void OnBGMVolumeChanged(float volume)
    {
        AudioManager.Instance.SetBGMVolume(volume);
    }

    void OnSEVolumeChanged(float volume)
    {
        AudioManager.Instance.SetSEVolume(volume);
    }
}

