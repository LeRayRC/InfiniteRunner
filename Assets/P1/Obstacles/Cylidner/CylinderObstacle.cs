using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Cylinder Obstacle", menuName = "MyAutorun/Obstacles/New Cylinder", order = 101)]
public class CylinderObstacle : ObstacleData
{
    // Start is called before the first frame update
    public float speedRotation_;

    public override GameObject InstantiateOnGame(ObstaclesController oc_)
    {
        // Transform furthestTr_ = oc_.GetFurthestTerrain();
        Vector3 new_position = new Vector3();
        Vector3 edge_position;
        GameObject obstacleGo_ = null;
        //Forward obstacle
        edge_position = new Vector3(oc_.lastGeneratedObstacle.transform.forward.x * oc_.lastGeneratedObstacle.transform.localScale.x * 0.5f,
                                    oc_.lastGeneratedObstacle.transform.forward.y * oc_.lastGeneratedObstacle.transform.localScale.y * 0.5f,
                                    oc_.lastGeneratedObstacle.transform.forward.z * oc_.lastGeneratedObstacle.transform.localScale.z * 0.5f);
        new_position = oc_.lastGeneratedObstacle.transform.position + edge_position + oc_.lastGeneratedObstacle.transform.forward * oc_.spaceBetweenObstacles;

        obstacleGo_ = Instantiate<GameObject>(obstaclePrefab_,new_position,oc_.lastGeneratedObstacle.transform.rotation);

        obstacleGo_.transform.Translate(TranslateHalfScale(obstacleGo_.transform, oc_.lastGeneratedObstacle.transform));
        
        // Debug.Log("New position" + new_position);
        // Debug.Log("Edge position" + edge_position);
        
        
        return obstacleGo_;
    }
}
