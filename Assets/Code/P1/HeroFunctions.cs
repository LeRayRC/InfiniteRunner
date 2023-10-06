using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroFunctions : MonoBehaviour
{
    private Vector3 spawnPonint_;
    // Start is called before the first frame update
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
        transform.position = spawnPonint_;
    }
}
