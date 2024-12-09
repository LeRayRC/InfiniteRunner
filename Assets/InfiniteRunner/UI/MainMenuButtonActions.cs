using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtonActions : MonoBehaviour
{
    public CanvasGroup canvasGroup; // Asigna el CanvasGroup del Panel aquí en el Inspector
    public float fadeDuration = 1.5f; // Duración del desvanecimiento en segundos
    public Button playButton;
    public Button quitButton;
    public Button settingsButton;
    public AudioClip audioTrack;
    public AudioManager audioManager;
    
    
    private void Start()
    {
        Time.timeScale = 1.0f;
        if (canvasGroup == null)
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }
        playButton.onClick.AddListener(() => FadeOut());
        quitButton.onClick.AddListener(() => QuitGame());
        settingsButton.onClick.AddListener(() => SettingsButton());
        //AudioManager.instance.ReturnToDefault();
    }
    
    
    public void FadeOut()
    {
        StartCoroutine(FadeCanvasGroup(canvasGroup, canvasGroup.alpha, 0.0f));
        audioManager.SwapTrack(audioTrack);
    }


    public void QuitGame()
    {
        Application.Quit();
    }

    public void SettingsButton()
    {
        UIManager.instance.currentUIPanel = UIPanel.UI_Settings;
    }

    private System.Collections.IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end=0.0f)
    {
        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            cg.alpha = Mathf.Lerp(start, end, elapsed / fadeDuration);
            yield return null;
        }

        cg.alpha = end;
        if (end <= 0.0f)
        {
            // cg.gameObject.SetActive(false);
            UIManager.instance.currentUIPanel = UIPanel.UI_None;
            SceneManager.LoadScene(1, LoadSceneMode.Additive);
        }
    }
}
