using UnityEngine;

public class CoinSound : MonoBehaviour
{
    public AudioSource coinAudio;

    public void PlayCoinSound()
    {
        coinAudio.Play();
    }
}