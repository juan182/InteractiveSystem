using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private List<AudioClip> effect = new List<AudioClip>();
    [SerializeField] private List<AudioClip> music = new List<AudioClip>();

    [Header("🎵 Volúmenes")]
    [SerializeField, Range(0f, 1f)] private float musicVolume = 1f;
    [SerializeField, Range(0f, 1f)] private float effectVolume = 1f;

    private AudioSource musicSource;
    private AudioSource effectSource;

    private void Awake()
    {
        musicSource = gameObject.AddComponent<AudioSource>();
        effectSource = gameObject.AddComponent<AudioSource>();

        musicSource.loop = true;
    }

    private void Start()
    {
        // Música inicial
        MusicReproduction(0);
    }

    public void EffectReproduction(int indice)
    {
        if (indice >= 0 && indice < effect.Count && effect[indice] != null)
        {
            effectSource.volume = effectVolume; // 🔹 Usar volumen de efectos
            effectSource.PlayOneShot(effect[indice]);
        }
    }

    public void MusicReproduction(int indice)
    {
        if (indice >= 0 && indice < music.Count && music[indice] != null)
        {
            musicSource.volume = musicVolume; // 🔹 Usar volumen de música
            musicSource.clip = music[indice];
            musicSource.Play();
        }
    }

    // 🔹 Permite cambiar volumen en tiempo real desde el inspector
    private void Update()
    {
        musicSource.volume = musicVolume;
        effectSource.volume = effectVolume;
    }
}
