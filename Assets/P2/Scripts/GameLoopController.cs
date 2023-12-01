using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoopController : MonoBehaviour
{
    // Start is called before the first frame update
    //  public Shader shader_;

    void Start()
    {
        // GameManager.instance.gameLevel = 0;
        // GameManager.instance.timeElapsedOnGame = 0.0f;
        StartCoroutine(BlendingLevelMaterial(GameManager.instance.levelBackgrounds_[0]));
        // mesh_.material.color = new Color(0.0f,0.0f,0.0f,0.0f);
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

    IEnumerator BlendingLevelMaterial(MeshRenderer prev_renderer){  
        Material prev_mat = prev_renderer.material;
        // Material next_mat = next_renderer.material;
        while ( prev_mat.color.a >= 0.0f)
        {
            Debug.Log("Modifying alpha");
            // prev_mat.
            prev_mat.color = new Color(prev_mat.color.r, prev_mat.color.g, prev_mat.color.b, prev_mat.color.a - Time.deltaTime *0.1f);
            // mesh_.material = new Material(prev_mat);
            // next_mat.color = new Color(prev_mat.color.r, prev_mat.color.g, prev_mat.color.b, prev_mat.color.a + Time.deltaTime *0.5f);
            yield return null; // new WaitForSeconds(0.1f);
        }
        // next_mat.color = new Color(prev_mat.color.r, prev_mat.color.g, prev_mat.color.b, 1.0f);

    }
}
