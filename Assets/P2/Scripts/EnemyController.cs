using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Camera camera_;
    // Start is called before the first frame update
    public Vector3 moveDir_ = new Vector3();
    public Vector3 newPos_ = new Vector3();
    public float sinusSpeed_;
    public float sinusPhase_;
    public float amplitude_;
    public float moveSpeed_;
    public bool checkRight_;

    public EnemyMovementBehaviour behaviour_;
    public float sinusInitYpos;
    void Start()
    {
        sinusInitYpos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Movement(EnemyMovementBehaviour.Sinus);
        // transform.Translate(moveDir_ * moveSpeed_ * Time.deltaTime);
        CheckDestroyOnOffScreen();
    }

    public void SetDirection(Vector3 dir)
    {
        moveDir_ = dir;
    }

    public void CheckDestroyOnOffScreen()
    {
        float border;
        if (checkRight_)
        {
            border = camera_.ViewportToWorldPoint(Vector2.one).x;
            if(transform.position.x > border)
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            border = camera_.ViewportToWorldPoint(Vector2.zero).x;
            if (transform.position.x < border)
            {
                Destroy(this.gameObject);
            }
        }
    }

    public void Movement(EnemyMovementBehaviour behaviour){
        switch(behaviour){
            case EnemyMovementBehaviour.Sinus:
                Debug.Log("Sinus movement");
                // newPos_.y = transform.position.y + amplitude_ * Mathf.Sin(Time.time*sinusSpeed_);

                // newPos_.x = transform.position.x;
                newPos_.y = sinusInitYpos +  amplitude_ * Mathf.Sin(Time.time*sinusSpeed_ + sinusPhase_);
                newPos_.z = transform.position.z;
                // Debug.Log(newPos_);
                // // newPos_.x = cube_.transform.position.x; 
                // newPos_.z = transform.position.z; 
                newPos_.x = transform.position.x + moveSpeed_ * moveDir_.x * Time.deltaTime;
                transform.position = newPos_;
                break;
        }
    }


}
