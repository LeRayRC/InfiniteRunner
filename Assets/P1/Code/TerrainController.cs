using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class TerrainController : MonoBehaviour
{
    public List<GameObject> terrainsList_;
    public GameObject hero_;
    public float moveTerrainOffset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Iterate over list and check if one terrain is behind the
        //to teleport it towards

        foreach (GameObject go in terrainsList_){
            if(go.transform.position.z + go.transform.localScale.z + moveTerrainOffset < hero_.transform.position.z){
                go.transform.position = new Vector3(go.transform.position.x,
                                                    go.transform.position.y,
                                                    GetFurthestTerrain()+40);
            }
        }
    }

    public float GetFurthestTerrain(){
        float z_position = 0.0f;
        for(int i=0;i<terrainsList_.Count;i++){
            if(terrainsList_[i].transform.position.z > z_position){
                z_position = terrainsList_[i].transform.position.z;
            }
        }
        return z_position;
    }

    public void ResetTerrainPosition(Vector3 spawnPoint_){
        for(int i=0;i<terrainsList_.Count;i++){
            terrainsList_[i].transform.position = new Vector3(terrainsList_[i].transform.position.x,
                                                              terrainsList_[i].transform.position.y,
                                                              spawnPoint_.z + 40.0f * i);
        }
    }
}
