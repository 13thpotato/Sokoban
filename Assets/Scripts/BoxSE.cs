using UnityEngine;

//����SE�𑀍�
public class BoxSE : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        //SE�����蓖��
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayPushSE()
    {
        //�Đ����s���܂�
        audioSource.Play();
    }
}
