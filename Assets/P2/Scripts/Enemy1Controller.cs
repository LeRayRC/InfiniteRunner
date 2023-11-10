using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Controller : MonoBehaviour
{
    public Camera camera_;
    // Start is called before the first frame update
    public Vector3 moveDir_ = new Vector3();
    public float moveSpeed;
    public bool checkRight;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDir_ * moveSpeed * Time.deltaTime);
        CheckDestroyOnOffScreen();
    }

    public void SetDirection(Vector3 dir)
    {
        moveDir_ = dir;
    }

    public void CheckDestroyOnOffScreen()
    {
        float border;
        if (checkRight)
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
}
