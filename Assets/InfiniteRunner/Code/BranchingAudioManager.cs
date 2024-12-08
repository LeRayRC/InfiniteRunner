using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;




public class BranchingAudioManager : MonoBehaviour
{
    public List<AudioClip> audioClips;
    public ObstaclesController obstaclesController;
    // Start is called before the first frame update
    private float changeInterval;
    private float initDelay;
    public float offsetInterval;
    public bool isStarted = true;
    private float currentTime;
    public AudioSource audioSource;
    public float playVolume;
    
    public AudioClip audioClipToPlay;
    public AudioClip audioClipPlaying;
    void Awake()
    {
        currentTime = 0.0f;
        initDelay = 5.0f;
        isStarted = false;
    }

    void Start()
    {
        
        changeInterval = obstaclesController.timeBetweenDifficultyChange;
        audioSource.clip = audioClips[0];
        audioSource.volume = 0.0f;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= initDelay && !isStarted)
        {
            
            Debug.Log("Destroying " + currentTime + " " + initDelay);
            AudioManager.instance.StopMusic();
            isStarted = true;
            UpdateTrack();
            currentTime = 0.0f;
        }
        
        if (currentTime >= (changeInterval + offsetInterval))
        {
            //Do things
            UpdateTrack();
            
            currentTime = 0.0f;
        }
    }

    public void UpdateTrack()
    {
        switch (obstaclesController.difficulty_)
        {
            case ObstaclesController.Difficulty.Difficulty_Easy:
                audioSource.clip = audioClips[0];
                break;
            case ObstaclesController.Difficulty.Difficulty_Medium:
                audioSource.clip = audioClips[1];
                break;
            case ObstaclesController.Difficulty.Difficulty_Hard:
                audioSource.clip = audioClips[0];
                break;
            default:
                audioSource.clip = audioClips[0];
                break;
        }
        
        audioSource.Play();
        audioSource.volume = playVolume;
    }
}
