using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject hero_;
    public GameObject deathPlane_;

    public Vector3 dir_ = new Vector3();
    private Vector3 spawnPoint_ = new Vector3();

    public float speed_;
    public float speedForward_;
    public float jumpForce_;

    private Rigidbody heroRb_;
    void Start()
    {
        spawnPoint_ = hero_.transform.position;

        heroRb_ = hero_.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)){
            Debug.Log("Moving forward");
        }
        if(Input.GetKey(KeyCode.S))
        {
            Debug.Log("Moving backwards");
        }
        if (Input.GetKey(KeyCode.A))
        {
            hero_.transform.position += Vector3.left * speed_ * Time.deltaTime;
            //Debug.Log("Moving Left");
        }
        if (Input.GetKey(KeyCode.D))
        {
            hero_.transform.position += Vector3.right * speed_ * Time.deltaTime;
            //Debug.Log("Moving Right");
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("Moving forward");
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("Moving backwards");
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("Moving Left");
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("Moving Right");
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Return");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            heroRb_.AddForce(Vector3.up * jumpForce_, ForceMode.Impulse);
            Debug.Log("Jumping");
        }

        hero_.transform.position += Vector3.forward * speedForward_ * Time.deltaTime;

        deathPlane_.transform.position = Vector3.Lerp(deathPlane_.transform.position,
                                                      new Vector3(hero_.transform.position.x,
                                                                  deathPlane_.transform.position.y,
                                                                  hero_.transform.position.z),1.0f);
    }
}
