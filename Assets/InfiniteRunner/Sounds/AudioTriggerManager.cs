using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTriggerManager : MonoBehaviour
{
    GameManager gameManager;
    public Difficulty difficultyAudioZone;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnTriggerEnter(Collider other){
        if(other.gameObject.layer == LayerMask.NameToLayer("Player")){
            if (gameManager) {
                gameManager.currentDifficultyAudioZone = difficultyAudioZone;
            }
        }
    }
}
