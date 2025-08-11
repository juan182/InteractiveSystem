using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private List<AudioClip> effect = new List<AudioClip>();

    [SerializeField]
    private List<AudioClip> music = new List<AudioClip>();

    private AudioSource audioSource;

    private void Awake()
    {
        // Esto no es necesario
        //Solo lo cree para que funcione asi no tengas audio
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void EffectReproduction(int indice)
    {
        if (indice >= 0 && indice < effect.Count)
        {
            audioSource.loop = false;
            audioSource.clip = effect[indice];
            audioSource.Play();
        }
    }

    public void MusicReproduction(int indice)
    {
        if (indice >= 0 && indice < music.Count)
        {
            audioSource.clip = music[indice];
            audioSource.loop = true; // aseguramos que sí se repita
            audioSource.Play();
        }
    }
}
