using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyMovementBehaviour{
    Sinus,
    Kamikaze,
    Vertical,
}

public enum SideSpawned{
    Left,
    Right,
}

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject spawnerLeft_;
    public GameObject spawnerRight_;

    public List<GameObject> enemyPrefabs_;

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
        int selectedEnemy = Random.Range(0,enemyPrefabs_.Count);


        if((SideSpawned)Random.Range(0,2) == SideSpawned.Left)
        {
            // Spawn on left
            enemySpawned_ = Instantiate<GameObject>(enemyPrefabs_[selectedEnemy], spawnerLeft_.transform.position, spawnerLeft_.transform.rotation);

            switch((EnemyMovementBehaviour) selectedEnemy){
                case EnemyMovementBehaviour.Sinus:
                    EnemyController e1c;
                    e1c = enemySpawned_.GetComponent<EnemyController>();
                    e1c.camera_ = camera_;
                    e1c.checkRight_ = true;
                    e1c.moveDir_ = Vector2.right;
                    e1c.moveSpeed_ = enemySpeed_;
                    break;
                case EnemyMovementBehaviour.Kamikaze:
                    EnemyCircularController ecc_ = enemySpawned_.GetComponent<EnemyCircularController>();
                    ecc_.mov_dir_ = Vector2.right;
                    ecc_.mov_speed_ = enemySpeed_;
                    ecc_.checkRight_ = true;
                    ecc_.rot_flow_ = 1.0f;
                    break;
            }
            

        }
        else
        {
            enemySpawned_ = Instantiate<GameObject>(enemyPrefabs_[selectedEnemy], spawnerRight_.transform.position, spawnerRight_.transform.rotation);


            switch((EnemyMovementBehaviour) selectedEnemy){
                case EnemyMovementBehaviour.Sinus:
                    EnemyController e1c;
                    e1c = enemySpawned_.GetComponent<EnemyController>();
                    e1c.camera_ = camera_;
                    e1c.checkRight_ = false;
                    e1c.moveDir_ = Vector2.left;
                    e1c.moveSpeed_ = enemySpeed_;
                    break;
                case EnemyMovementBehaviour.Kamikaze:
                    EnemyCircularController ecc_ = enemySpawned_.GetComponent<EnemyCircularController>();
                    ecc_.mov_dir_ = Vector2.left;
                    ecc_.mov_speed_ = enemySpeed_;
                    ecc_.checkRight_ = false;
                    ecc_.rot_flow_ = -1.0f;
                    break;
            }
            // Spawn on right
            
        }
    }

    public void SpawnEnemyHorde()
    {
        
    }

    IEnumerator SpawnWaveEnemy(EnemyMovementBehaviour enemyBehaviour){
        int side = Random.Range(0,2);
        for(int i=0;i<GameManager.instance.enemyWaveSize;i++){
            switch(enemyBehaviour){
                case EnemyMovementBehaviour.Sinus:
                    if(side == 0){
                        // Spawn on left
                        enemySpawned_ = Instantiate<GameObject>(enemyPrefabs_[0], spawnerLeft_.transform.position, spawnerLeft_.transform.rotation);
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
                        enemySpawned_ = Instantiate<GameObject>(enemyPrefabs_[0], spawnerRight_.transform.position, spawnerRight_.transform.rotation);
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
                case EnemyMovementBehaviour.Kamikaze:
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
