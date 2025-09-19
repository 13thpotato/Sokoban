using UnityEngine;

//” ‚ÌSE‚ğ‘€ì
public class BoxSE : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        //SE‚ğŠ„‚è“–‚Ä
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayPushSE()
    {
        //Ä¶‚ğs‚¢‚Ü‚·
        audioSource.Play();
    }
}
