using UnityEngine;

public class AudioEventTool : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip sound;

    public void PlaySound()
    {
        audioSource.PlayOneShot(sound);
    }
}