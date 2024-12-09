using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum UIPanel
{
    UI_Main,
    UI_Settings,
    UI_Pause,
    UI_None,
}

public class UIManager : MonoBehaviour
{
    public UIPanel currentUIPanel;
    public GameObject MainPanel;
    public GameObject SettingsPanel;
    public static UIManager instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        currentUIPanel = UIPanel.UI_Main;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentUIPanel)
        {
            case UIPanel.UI_Main:
                MainPanel.SetActive(true);
                SettingsPanel.SetActive(false);
                break;
            case UIPanel.UI_Settings:
                MainPanel.SetActive(false);
                SettingsPanel.SetActive(true);
                break;
            case UIPanel.UI_None:
                MainPanel.SetActive(false);
                SettingsPanel.SetActive(false);
                break;
        }
    }
}
