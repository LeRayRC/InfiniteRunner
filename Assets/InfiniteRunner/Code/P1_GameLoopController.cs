using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameState{
    STARTED,
    PAUSED,
    SCORE,
}

public class P1_GameLoopController : MonoBehaviour
{
    private GameState state_;
    // public Image image_;
    public Image score_;
    public TMP_Text scoreText_;
    // Start is called before the first frame update
    void Start()
    {
        state_ = GameState.STARTED;
        // image_.gameObject.SetActive(true);
        score_.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if ( state_ == GameState.PAUSED){
            Time.timeScale = 0.0f;
        }else if (state_ == GameState.STARTED){
            Time.timeScale = 1.0f;
        }
    }

    public void PlayGame(){
        state_ = GameState.STARTED;
        Time.timeScale = 1.0f;
        GameManager.instance.currentDifficultyAudioZone = Difficulty.Difficulty_None;
        GameManager.instance.playerKilled = false;
        // image_.gameObject.SetActive(false);
        score_.gameObject.SetActive(false);
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void PauseGame(){
        state_ = GameState.PAUSED;
        Time.timeScale = 0.0f;
        // image_.gameObject.SetActive(true);
        score_.gameObject.SetActive(false);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void ShowScoreTable(int score, int distance){
        state_ = GameState.SCORE;
        Time.timeScale = 0.0f;
        // image_.gameObject.SetActive(false);
        score_.gameObject.SetActive(true);

        scoreText_.text = "You got " + score + " coins \nduring " + distance + " m";
    }
}
