using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ToggleActions : MonoBehaviour
{
    public Toggle layeringToggle;
    public Toggle branchingToggle;
    void Awake()
    {
        if (layeringToggle != null)
        {
            layeringToggle.onValueChanged.AddListener(OnLayeringToggleValueChanged);
            GameManager.instance.layeringEnabled = layeringToggle.isOn;
        }
        if (branchingToggle != null)
        {
            branchingToggle.onValueChanged.AddListener(OnBranchingToggleValueChanged);
            GameManager.instance.branchingEnabled = layeringToggle.isOn;
        }

        
    }
    
    private void OnLayeringToggleValueChanged(bool value)
    {
        GameManager.instance.layeringEnabled = value;
    }
    
    private void OnBranchingToggleValueChanged(bool value)
    {
        GameManager.instance.branchingEnabled = value;
    }
}
