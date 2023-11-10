using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUps{

    
    public bool doubleFire;
    public bool tripleFire;
    public bool shotgunFire;
    public bool laser;

    public PowerUps(){
        doubleFire = false;
        tripleFire = false;
        shotgunFire = false;
        laser = false;
    }
}

public class ShipShooting : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject ship_;
    public GameObject bullet_;
    public GameObject centralWeapon_;
    public GameObject leftWeapon_;
    public GameObject rightWeapon_;

    public float fireCooldown_;
    public float timeSinceLastFire_;

    public float standardfireCooldown_;
    public float laserFireCooldown_;
    PowerUps powerUps_ = new PowerUps();
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1)){
            powerUps_.doubleFire = !powerUps_.doubleFire;
        }

        if(Input.GetKeyDown(KeyCode.F2)){
            powerUps_.tripleFire = !powerUps_.tripleFire;
        }

        if(Input.GetKeyDown(KeyCode.F3)){
            powerUps_.shotgunFire = !powerUps_.shotgunFire;
        }

        if(Input.GetKeyDown(KeyCode.F4)){
            powerUps_.laser = !powerUps_.laser;
        }

        timeSinceLastFire_ += Time.deltaTime;
        if(timeSinceLastFire_ >= fireCooldown_){
            timeSinceLastFire_ = 0.0f;
            Fire();
        }

        if(powerUps_.laser){
            fireCooldown_ = laserFireCooldown_;
        }else{
            fireCooldown_ = standardfireCooldown_;
        }
    }

    public void Fire(){
        if(powerUps_.tripleFire){
            if(powerUps_.shotgunFire){
                InitBullet(rightWeapon_, Vector3.up);
                InitBullet(rightWeapon_,60.0f);
                InitBullet(rightWeapon_,120.0f);

                InitBullet(leftWeapon_, Vector3.up);
                InitBullet(leftWeapon_,60.0f);
                InitBullet(leftWeapon_,120.0f);

                InitBullet(centralWeapon_, Vector3.up);
                InitBullet(centralWeapon_,60.0f);
                InitBullet(centralWeapon_,120.0f);

            }else{
                InitBullet(rightWeapon_, Vector3.up);
                InitBullet(leftWeapon_, Vector3.up);
                InitBullet(centralWeapon_, Vector3.up);
            }
        }
        if(powerUps_.doubleFire){
            if(powerUps_.shotgunFire){
                InitBullet(rightWeapon_, Vector3.up);
                InitBullet(rightWeapon_,60.0f);
                InitBullet(rightWeapon_,120.0f);

                InitBullet(leftWeapon_, Vector3.up);
                InitBullet(leftWeapon_,60.0f);
                InitBullet(leftWeapon_,120.0f);

            }else{
                InitBullet(rightWeapon_, Vector3.up);
                InitBullet(leftWeapon_, Vector3.up);
            }
        }else{
            if(powerUps_.shotgunFire){
                InitBullet(centralWeapon_, Vector3.up);
                InitBullet(centralWeapon_,60.0f);
                InitBullet(centralWeapon_,120.0f);
            }else{
                InitBullet(centralWeapon_, Vector3.up);
            }
        }
    }

    public void InitBullet(GameObject prefab, Vector3 bulletDir, float angle = 0.0f){
        GameObject go;
        go = Instantiate<GameObject>(bullet_, prefab.transform.position,prefab.transform.rotation);
        go.GetComponent<BulletController>().bulletDir_ = bulletDir;
        prefab.GetComponent<ParticleSystem>().Play();
    }

    public void InitBullet(GameObject prefab,float angle){
        GameObject go;
        Vector3 bulletDir = new Vector3();
        bulletDir.x = Mathf.Cos(angle * Mathf.PI / 180.0f);
        bulletDir.y = Mathf.Sin(angle * Mathf.PI / 180.0f);
        bulletDir.z = 0.0f;
        go = Instantiate<GameObject>(bullet_, prefab.transform.position,prefab.transform.rotation);
        go.transform.Rotate(new Vector3(0.0f,0.0f,angle + 90.0f ));
        go.GetComponent<BulletController>().bulletDir_ = bulletDir;

        prefab.GetComponent<ParticleSystem>().Play();
    }
}
