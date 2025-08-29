using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource bgmSource;
    public AudioSource[] seSources;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        // �V�[���J�ڌ�� AudioSource ���Ď擾
        if (bgmSource == null)
        {
            bgmSource = GetComponent<AudioSource>();
        }

        if (seSources == null || seSources.Length == 0)
        {
            seSources = GetComponentsInChildren<AudioSource>();
        }
    }

    public void SetBGMVolume(float volume)
    {
        if (bgmSource != null)
            bgmSource.volume = volume;
    }

    public void SetSEVolume(float volume)
    {
        if (seSources != null)
        {
            foreach (var se in seSources)
            {
                if (se != null)
                    se.volume = volume;
            }
        }
    }
}

