using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip backgroundMusic;

    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = backgroundMusic;
        audio.loop = true;
        audio.Play();
    }
}
