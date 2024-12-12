using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum Difficulty{
    Difficulty_Easy,
    Difficulty_Medium,
    Difficulty_Hard,
    Difficulty_None,
}



public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Difficulty currentDifficultyAudioZone;
    public bool gamePaused;
    public bool gameRunning;
    public bool layeringEnabled;
    public bool branchingEnabled;
    public bool playerKilled;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    public void Start()
    {
        gamePaused = false;
        gameRunning = false;
        layeringEnabled = true;
        branchingEnabled = true;
        playerKilled = false;
    }

    
    
}
