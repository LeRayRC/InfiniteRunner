using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    public float bulletSpeed_;
    public Vector3 bulletDir_;
    public float lifeTime_;

    void Start(){
        Destroy(this.gameObject,lifeTime_);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(bulletDir_ * bulletSpeed_ * Time.deltaTime, Space.World);
    }
}
