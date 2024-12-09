using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System.Timers;
using System;



public class BranchingAudioManager : MonoBehaviour
{
    private Timer checkAudioZoneTimer;
    public float checkAudioZoneTimerInterval;
    private GameManager gameManager;
    
    
    public AudioClip easyZoneAudioClip;
    public AudioClip mediumZoneAudioClip;
    
    public ObstaclesController obstaclesController;
    private float currentTime;
    private AudioSource audioSource;
    public float playVolume;
    public float initVolumeProgress;
    
    public Difficulty difficultyAudioPlaying;
    void Awake()
    {
        currentTime = 0.0f;
    }

    void Start()
    {
        gameManager = GameManager.instance;
        
        checkAudioZoneTimer = new Timer(checkAudioZoneTimerInterval);
        checkAudioZoneTimer.Elapsed += OnTimerElapsedCheck;
        checkAudioZoneTimer.AutoReset = true;
        checkAudioZoneTimer.Enabled = true;

        difficultyAudioPlaying = Difficulty.Difficulty_None;
        
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.branchingEnabled) return;
        
        if (audioSource.isPlaying)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(0.0f, playVolume, currentTime / initVolumeProgress);
        }
        else
        {
            currentTime = 0.0f;
        }
        
        switch (difficultyAudioPlaying) {
            case Difficulty.Difficulty_None:
                audioSource.Stop();
                break;
            case Difficulty.Difficulty_Easy:
                audioSource.clip = easyZoneAudioClip;
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
                break;
            case Difficulty.Difficulty_Medium:
                audioSource.clip = mediumZoneAudioClip;
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
                break;
            case Difficulty.Difficulty_Hard:
                break;
            default:
                break;
        }
        

    }
    
    private void OnTimerElapsedCheck(object sender, ElapsedEventArgs e)
    {
        Debug.Log($"Timer elapsed at {DateTime.Now}");
        if (gameManager)
        {
            difficultyAudioPlaying = gameManager.currentDifficultyAudioZone;
        }
    }
    
    void OnDestroy()
    {
        // Limpia el timer cuando el objeto se destruye
        if (checkAudioZoneTimer != null)
        {
            checkAudioZoneTimer.Stop();
            checkAudioZoneTimer.Dispose();
        }
    }
}
