using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlane : MonoBehaviour
{
    // Start is called before the first frame update
    public ObstaclesController oc_;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Hero")
        {
            HeroFunctions hf_ = other.GetComponent<HeroFunctions>();
            hf_.MoveToSpawn();
            oc_.ResetTerrainPosition(hf_.GetSpawnPoint());
        }
    }
}
