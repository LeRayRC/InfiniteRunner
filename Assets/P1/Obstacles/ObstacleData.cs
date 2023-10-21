using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [CreateAssetMenu(fileName = "New Obstacle", menuName = "MyAutorun/Obstacles/New Obstacle", order = 101)]
public class ObstacleData : ScriptableObject
{
    
    // Start is called before the first frame update
    public GameObject obstaclePrefab_;

    public virtual GameObject InstantiateOnGame(ObstaclesController oc_){
        return null;
    }

    public virtual Vector3 TranslateHalfScale(Transform tr_, Transform parentTr_=null, bool changeDirection=false){
        Vector3 translate_pos = new Vector3();

        translate_pos.x = tr_.localScale.x * 0.5f * tr_.forward.x;
        translate_pos.y = tr_.localScale.y * 0.5f * tr_.forward.y;
        translate_pos.z = tr_.localScale.z * 0.5f * tr_.forward.z;

        return translate_pos;
    }
}
