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
    
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }
    
    
}
