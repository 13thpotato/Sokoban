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
        panel.SetActive(false); // ������\��

        bgmSlider.onValueChanged.AddListener(OnBGMVolumeChanged);
        seSlider.onValueChanged.AddListener(OnSEVolumeChanged);

        // �����l��AudioManager����擾�i�K�v�Ȃ�ۑ��f�[�^����j
        bgmSlider.value = AudioManager.Instance.bgmSource.volume;
        if (AudioManager.Instance.seSources.Length > 0)
            seSlider.value = AudioManager.Instance.seSources[0].volume;
    }

    void Update()
    {
        //esc�L�[�ŉ��ʒ�����ʂ�\��
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

