using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioManager() { }
    public static AudioManager Instance { get; private set; }

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioSource buttonSource;

    public float soundVolume = 1.0f;
    public float bgmVolume = 1.0f;

    private bool fadelnMusicflag = false;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            transform.parent = null;
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayMusic(AudioClip clip)
    {
        if (!clip) return;

        musicSource.clip = clip;
        musicSource.volume = bgmVolume;
        musicSource.Play();
    }

    public void PlayOneShot(AudioClip clip)
    {
        if (!clip) return;

        sfxSource.clip = clip;
        sfxSource.volume = soundVolume;
        sfxSource.PlayOneShot(sfxSource.clip);
    }

    public void PlayOneShotButton(AudioClip clip)
    {
        if (!clip) return;

        buttonSource.clip = clip;
        buttonSource.volume = soundVolume;
        buttonSource.PlayOneShot(buttonSource.clip);
    }

    public IEnumerator Fadeln(AudioSource audioSource, float fadeTime)
    {
        float startVolume = 0.0f;
        audioSource.volume = startVolume;
        audioSource.Play();

        while (audioSource.volume < bgmVolume)
        {
            audioSource.volume += bgmVolume * Time.deltaTime / fadeTime;
            yield return null;
        }
    }

    public IEnumerator Fadeout(AudioSource audioSource, float fadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0.0f)
        {
            audioSource.volume -= startVolume * Time.deltaTime / fadeTime;
            yield return null;
        }
        audioSource.Stop();
    }

    public void FadeInMuisc(AudioClip newMusic, float fadeTime)
    {
        if (!newMusic) return;
        if (fadelnMusicflag) return;

        StartCoroutine(FadeInMuicroutine(newMusic, fadeTime));
    }

    public IEnumerator FadeInMuicroutine(AudioClip newMusic, float fadeTime)
    {
        fadelnMusicflag = true;
        yield return StartCoroutine(Fadeout(musicSource, fadeTime));

        musicSource.clip = newMusic;
        yield return StartCoroutine(Fadeln(musicSource, fadeTime));

        fadelnMusicflag = false;
    }

}
