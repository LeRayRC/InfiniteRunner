using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyCircularController : MonoBehaviour
{
    public GameObject player_;
    public GameObject ship_child;
    public float mov_speed_;
    public float rot_speed_;
    public float rot_flow_;
    public Vector3 mov_dir_;
    Transform tr_;
    public Camera camera_;
    // Start is called before the first frame update
    public bool checkRight_;
    void Start()
    {
        camera_ = GameManager.instance.camera_;
        player_ = GameManager.instance.player_;

        tr_ = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
        tr_.Translate(mov_dir_ * mov_speed_ * Time.deltaTime, Space.World);
        tr_.Rotate(new Vector3(0.0f,0.0f,rot_speed_ * rot_flow_ * Time.deltaTime),Space.World);

        CheckDestroyOnOffScreen();
    }

    public void CheckDestroyOnOffScreen()
    {
        float border;
        if (checkRight_)
        {
            border = camera_.ViewportToWorldPoint(Vector2.one).x;
            if(transform.position.x > border)
            {
                Destroy(this.gameObject, 1.0f);
            }
        }
        else
        {
            border = camera_.ViewportToWorldPoint(Vector2.zero).x;
            if (transform.position.x < border)
            {
                Destroy(this.gameObject, 1.0f);
            }
        }
    }
}
