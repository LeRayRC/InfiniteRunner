using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip defaultAmbience;
    private AudioSource track01, track02;
    private bool isPlayingTrack01;
    public static AudioManager instance;
    public float maxVolume01;
    public float maxVolume02;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        track01 = gameObject.AddComponent<AudioSource>();
        track02 = gameObject.AddComponent<AudioSource>();
        isPlayingTrack01 = true;
        track01.loop = true;
        track02.loop = true;
        SwapTrack(defaultAmbience);
    }

    public void StopMusic()
    {
        Destroy(this.gameObject, 0.5f);
    }

    public void SwapTrack(AudioClip newClip)
    {
        StopAllCoroutines();

        StartCoroutine(FadeTrack(newClip));
        isPlayingTrack01 = !isPlayingTrack01;
    }

    public void ReturnToDefault()
    {
        //StopAllCoroutines();

        //track02.volume = 1.0f;
        //track01.volume = 1.0f;
        //SwapTrack(defaultAmbience);

        //// Reproducir la pista predeterminada en la pista activa
        //if (isPlayingTrack01)
        //{
        //    track01.clip = defaultAmbience;
        //    track01.Play();
        //}
        //else
        //{
        //    track02.clip = defaultAmbience;
        //    track02.Play();
        //}

        StopAllCoroutines(); 
        // track02.volume = maxVolume02;
        // track01.volume = maxVolume01;
        // Iniciar el fade hacia la pista predeterminada
        StartCoroutine(FadeTrack(defaultAmbience));
    }

    private IEnumerator FadeTrack(AudioClip newClip)
    {
        float timeToFade = 3.25f;
        float timeElapsed = 0f;

        if (isPlayingTrack01)
        {
            track02.clip = newClip;
            track02.Play();

            while (timeElapsed < timeToFade)
            {

                track02.volume = Mathf.Lerp(0, maxVolume02, timeElapsed / timeToFade);
                track01.volume = Mathf.Lerp(maxVolume01, 0, timeElapsed / timeToFade);
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            track01.Stop();

        }
        else
        {
            track01.clip = newClip;
            track01.Play();

            while (timeElapsed < timeToFade)
            {
                track01.volume = Mathf.Lerp(0, maxVolume01, timeElapsed / timeToFade);
                track02.volume = Mathf.Lerp(maxVolume02, 0, timeElapsed / timeToFade);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            track02.Stop();

        }
    }
}
