using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoopController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // GameManager.instance.gameLevel = 0;
        // GameManager.instance.timeElapsedOnGame = 0.0f;

    }

    // Update is called once per frame
    void Update()
    {
        GameManager.instance.timeElapsedOnGame += Time.deltaTime;
        if(GameManager.instance.timeElapsedOnGame > GameManager.instance.timeToChangeLevel){
            GameManager.instance.timeElapsedOnGame = 0.0f;
            GameManager.instance.gameLevel++;
        }
    }
}
