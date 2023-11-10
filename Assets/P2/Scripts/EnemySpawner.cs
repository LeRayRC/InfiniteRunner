using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject spawnerLeft_;
    public GameObject spawnerRight_;

    public GameObject enemyPrefab1_;
    public GameObject enemyPrefab2_;

    GameObject enemySpawned_ = null;

    public float enemySpawnCooldwon_;
    public float timeElapsedSinceLastEnemySpawned_;
    public int enemiesSpawnedCount_;

    public float enemy1Speed_; 

    public Camera camera_;
    void Start()
    {
        timeElapsedSinceLastEnemySpawned_ = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsedSinceLastEnemySpawned_ += Time.deltaTime;
        if(timeElapsedSinceLastEnemySpawned_ > enemySpawnCooldwon_)
        {
            enemiesSpawnedCount_++;
            if(enemiesSpawnedCount_ % 5 == 0)
            {
                Debug.Log("Spawn Horde");
            }
            else
            {
                SpawnEnemy();
            }
            timeElapsedSinceLastEnemySpawned_ = 0.0f;
        }
    }

    public void SpawnEnemy()
    {
        if(Random.Range(0,2) == 0)
        {
            // Spawn on left
            enemySpawned_ = Instantiate<GameObject>(enemyPrefab1_, spawnerLeft_.transform.position, spawnerLeft_.transform.rotation);
            Enemy1Controller e1c;
            e1c = enemySpawned_.GetComponent<Enemy1Controller>();
            e1c.camera_ = camera_;
            e1c.checkRight = true;
            e1c.moveDir_ = Vector2.right;
            e1c.moveSpeed = enemy1Speed_;

        }
        else
        {
            // Spawn on right
            enemySpawned_ = Instantiate<GameObject>(enemyPrefab1_, spawnerRight_.transform.position, spawnerRight_.transform.rotation);
            Enemy1Controller e1c;
            e1c = enemySpawned_.GetComponent<Enemy1Controller>();
            e1c.camera_ = camera_;
            e1c.checkRight = false;
            e1c.moveDir_ = Vector2.left;
            e1c.moveSpeed = enemy1Speed_;
        }
    }

    public void SpawnEnemyHorde()
    {

    }
}
