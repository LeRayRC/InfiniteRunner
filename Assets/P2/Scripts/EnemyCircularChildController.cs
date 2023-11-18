using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCircularChildController : MonoBehaviour
{
    // Start is called before the first frame update
    float time_to_attack;
    public float speed_;
    public bool kamikaze_activated_;
    public Vector3 forward_dir_;
    void Start()
    {
        kamikaze_activated_ = false;
        time_to_attack = Random.Range(2.0f, 4.0f);
    }

    // Update is called once per frame
    void Update()
    {
        time_to_attack -= Time.deltaTime;
        if ( time_to_attack <= 0.0f){
            
            transform.SetParent(null);
            kamikaze_activated_ = true;
        }

        if( kamikaze_activated_){
            transform.Translate(transform.up * speed_ * Time.deltaTime, Space.World);
        }else{
            forward_dir_ = GameManager.instance.player_.transform.position - transform.position;
            forward_dir_.Normalize();
            transform.up = forward_dir_;
        }
    }
}
