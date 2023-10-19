using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlane : MonoBehaviour
{
    // Start is called before the first frame update
    public TerrainController tc_;

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
            tc_.ResetTerrainPosition(hf_.GetSpawnPoint());
        }
    }
}
