using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyMovementBehaviour{
    Normal,
    Sinus,
    Suicide,
    Vertical,
}

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

    public float enemySpeed_; 
    public float enemyHordeTimeBetweenEnemy;
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
            if(enemiesSpawnedCount_ % GameManager.instance.enemyWaveRatio == 0)
            {
                // Hay que hacer un random para el tipo de horda
                StartCoroutine(SpawnWaveEnemy(EnemyMovementBehaviour.Sinus));
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
            EnemyController e1c;
            e1c = enemySpawned_.GetComponent<EnemyController>();
            e1c.camera_ = camera_;
            e1c.checkRight_ = true;
            e1c.moveDir_ = Vector2.right;
            e1c.moveSpeed_ = enemySpeed_;

        }
        else
        {
            // Spawn on right
            enemySpawned_ = Instantiate<GameObject>(enemyPrefab1_, spawnerRight_.transform.position, spawnerRight_.transform.rotation);
            EnemyController e1c;
            e1c = enemySpawned_.GetComponent<EnemyController>();
            e1c.camera_ = camera_;
            e1c.checkRight_ = false;
            e1c.moveDir_ = Vector2.left;
            e1c.moveSpeed_ = enemySpeed_;
        }
    }

    public void SpawnEnemyHorde()
    {

    }

    IEnumerator SpawnWaveEnemy(EnemyMovementBehaviour enemyBehaviour){
        int side = Random.Range(0,2);
        for(int i=0;i<GameManager.instance.enemyWaveSize;i++){
            switch(enemyBehaviour){
                case EnemyMovementBehaviour.Normal:
                    break;
                case EnemyMovementBehaviour.Sinus:
                    if(side == 0){
                        // Spawn on left
                        enemySpawned_ = Instantiate<GameObject>(enemyPrefab1_, spawnerLeft_.transform.position, spawnerLeft_.transform.rotation);
                        EnemyController e1c;
                        e1c = enemySpawned_.GetComponent<EnemyController>();
                        e1c.camera_ = camera_;
                        e1c.checkRight_ = true;
                        e1c.moveDir_ = Vector2.right;
                        e1c.moveSpeed_ = enemySpeed_;
                        e1c.behaviour_ = EnemyMovementBehaviour.Sinus;
                        // e1c.sinusPhase_ = Random.Range(0,Mathf.PI);
                        e1c.sinusPhase_ = (i *Mathf.PI) / GameManager.instance.enemyWaveSize;
                    }
                    else{
                        // Spawn on right
                        enemySpawned_ = Instantiate<GameObject>(enemyPrefab1_, spawnerRight_.transform.position, spawnerRight_.transform.rotation);
                        EnemyController e1c;
                        e1c = enemySpawned_.GetComponent<EnemyController>();
                        e1c.camera_ = camera_;
                        e1c.checkRight_ = false;
                        e1c.moveDir_ = Vector2.left;
                        e1c.moveSpeed_ = enemySpeed_;
                        e1c.behaviour_ = EnemyMovementBehaviour.Sinus;
                        // e1c.sinusPhase_ = Random.Range(0,Mathf.PI);
                        e1c.sinusPhase_ = (i *Mathf.PI) / GameManager.instance.enemyWaveSize;
                    }
                    break;
                case EnemyMovementBehaviour.Suicide:
                    break;
                case EnemyMovementBehaviour.Vertical:
                    break;
                default:
                    break;
            }
            yield return new WaitForSeconds(enemyHordeTimeBetweenEnemy);
        }
    }
}
