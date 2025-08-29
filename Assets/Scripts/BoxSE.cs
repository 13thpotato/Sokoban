using UnityEngine;

public class BoxSE : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayPushSE()
    {
        audioSource.Play();
    }
}
