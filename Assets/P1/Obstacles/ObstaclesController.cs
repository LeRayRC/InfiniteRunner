using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class ObstaclesController : MonoBehaviour
{
    public List<GameObject> obstaclesList_;
    public List<ObstacleData> obstaclesPrefabList_;

    [HideInInspector]
    public GameObject lastGeneratedObstacle;
    public GameObject hero_;
    public float moveTerrainOffset;
    public float spaceBetweenObstacles;
    public int minObstaclesBeforeChangeDirection;

    [HideInInspector]
    public int obstaclesGenerated;
    [HideInInspector]
    GameObject obstacleGo_;
    [HideInInspector]
    public bool changeDirection;

    public int initialObstacles;
    // Start is called before the first frame update
    void Start()
    {
        changeDirection = false;
        lastGeneratedObstacle = obstaclesList_[0];
        obstaclesGenerated = 0;
        for(int i=0;i<initialObstacles;i++){
            int prefab_selected = Random.Range(0,obstaclesPrefabList_.Count);
            if(obstaclesGenerated < minObstaclesBeforeChangeDirection){
                obstaclesGenerated++;
                //Generate normal obstacle
                obstacleGo_ = obstaclesPrefabList_[prefab_selected].InstantiateOnGame(this);
            }else{
                obstaclesGenerated = 0;
                changeDirection = true;
                //Generate plain direction with change right or left
                obstacleGo_ = obstaclesPrefabList_[0].InstantiateOnGame(this);
                changeDirection = false; 
            }
            
            if( obstacleGo_ != null){
                obstaclesList_.Add(obstacleGo_);
                lastGeneratedObstacle = obstacleGo_;
            }else{
                Debug.Log("Obstacle generated is null");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Iterate over list and check if one terrain is behind the
        //to teleport it towards

        foreach (GameObject go in obstaclesList_){
            if(go.transform.position.z + go.transform.localScale.z + moveTerrainOffset < hero_.transform.position.z){
                //Destroy gameobject and instantiate another
                Vector3 new_position = GetFurthestTerrain().position;
                new_position.z += spaceBetweenObstacles;
                go.transform.position = new_position;
            }
        }
    }

    public Transform GetFurthestTerrain(){
        Vector3 furthest_position = Vector3.zero;
        int furthest_index = 0;
        for(int i=0;i<obstaclesList_.Count;i++){
            if(obstaclesList_[i].transform.position.z > furthest_position.z){
                furthest_position = obstaclesList_[i].transform.position;
                furthest_index = i;
            }
        }
        return obstaclesList_[furthest_index].transform;
    }


    public void ResetTerrainPosition(Vector3 spawnPoint_){
        for(int i=0;i<obstaclesList_.Count;i++){
            obstaclesList_[i].transform.position = new Vector3(obstaclesList_[i].transform.position.x,
                                                              obstaclesList_[i].transform.position.y,
                                                              spawnPoint_.z + spaceBetweenObstacles * i);
        }
    }
}
