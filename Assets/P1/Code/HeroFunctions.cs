using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroFunctions : MonoBehaviour
{
    private Vector3 spawnPonint_;
    // Start is called before the first frame update
    public Vector3 GetSpawnPoint(){
        return spawnPonint_;
    }
    void Start()
    {
        spawnPonint_ = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveToSpawn()
    {
        transform.rotation = Quaternion.Euler(0.0f,0.0f,0.0f);
        transform.position = spawnPonint_;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
