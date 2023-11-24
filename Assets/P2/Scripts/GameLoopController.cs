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
        StartCoroutine(BlendingLevelMaterial(GameManager.instance.levelMaterials_[0], GameManager.instance.levelMaterials_[1]));
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

    IEnumerator BlendingLevelMaterial(Material prev_mat, Material next_mat){   
        while ( prev_mat.color.a >= 0.0f)
        {

            prev_mat.color = new Color(prev_mat.color.r, prev_mat.color.g, prev_mat.color.b, prev_mat.color.a - Time.deltaTime);
            next_mat.color = new Color(prev_mat.color.r, prev_mat.color.g, prev_mat.color.b, prev_mat.color.a + Time.deltaTime);
        }
        next_mat.color = new Color(prev_mat.color.r, prev_mat.color.g, prev_mat.color.b, 1.0f);

        yield return new WaitForSeconds(0.1f);
    }
}
