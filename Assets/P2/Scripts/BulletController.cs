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

    void OnCollisionEnter2D(Collision2D col)
    {   
        EnemyController ec_ = col.gameObject.GetComponent<EnemyController>();
        GameObject go_ = Instantiate<GameObject>(ec_.explosionParticles_, col.gameObject.transform.position, col.gameObject.transform.rotation);
        go_.GetComponentInChildren<ParticleSystem>().Play();
        Destroy(col.collider.gameObject,0.0f);
        Destroy(this.gameObject,0.0f);
    }
}
