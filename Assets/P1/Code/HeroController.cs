using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UIElements;

public class HeroController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject hero_;
    public GameObject deathPlane_;
    public Camera mainCamera_;

    private float initFOV;
    public float onAirFOV;

    public Vector3 dir_ = new Vector3();
    private Vector3 spawnPoint_ = new Vector3();

    public float speed_;
    private float speedForward_;
    public float onGroundSpeedForward_;
    public float onAirSpeedForward_;
    public float jumpForce_;
    public float gravityScale_;

    [SerializeField]
    private bool canJump_;

    private Rigidbody heroRb_;
    private CapsuleCollider heroCollider_;
    private Animator anim_;
    void Start()
    {
        spawnPoint_ = hero_.transform.position;

        heroRb_ = hero_.GetComponent<Rigidbody>();
        heroCollider_ = hero_.GetComponent<CapsuleCollider>();
        anim_ = hero_.GetComponent<Animator>();
        initFOV = mainCamera_.fieldOfView;
        Debug.Log(initFOV + " " + onAirFOV);
    }

    // Update is called once per frame
    void Update()
    {
        // RaycastHit hit;
        if(Physics.Raycast(hero_.transform.position + (Vector3.up * heroCollider_.height * 0.5f),Vector3.down, ((heroCollider_.height * 0.5f) + 0.01f), LayerMask.GetMask("Terrain"))){
            canJump_ = true;
            anim_.SetBool("OnAir",false);
            //Debug.Log("On Ground!");
            mainCamera_.fieldOfView = Mathf.Lerp(mainCamera_.fieldOfView, initFOV, 0.01f);
            speedForward_ = onGroundSpeedForward_;
        }
        else{
            canJump_ = false;
            anim_.SetBool("OnAir",true);
            //Debug.Log("On Air!");
            mainCamera_.fieldOfView = Mathf.Lerp(mainCamera_.fieldOfView, onAirFOV, 0.01f);
            speedForward_ = onAirSpeedForward_;
        }
        Debug.DrawRay(hero_.transform.position + (Vector3.up * heroCollider_.height * 0.5f),Vector3.down*((heroCollider_.height * 0.5f) + 0.01f));
        


        if(Input.GetKey(KeyCode.W)){
            Debug.Log("Moving forward");
        }
        if(Input.GetKeyDown(KeyCode.S) && anim_.GetCurrentAnimatorStateInfo(0).IsName("Running"))
        {
            // anim_.ResetTrigger("RollActivated");
            Debug.Log("Moving backwards");
            anim_.SetTrigger("RollActivated");
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
        if (Input.GetKeyDown(KeyCode.Space) && canJump_)
        {
            
            heroRb_.AddForce(Vector3.up * jumpForce_, ForceMode.Impulse);
            Debug.Log("Jumping");
            
        }


        deathPlane_.transform.position = Vector3.Lerp(deathPlane_.transform.position,
                                                      new Vector3(hero_.transform.position.x,
                                                                  deathPlane_.transform.position.y,
                                                                  hero_.transform.position.z),1.0f);

    }

    void FixedUpdate(){
        heroRb_.velocity = new Vector3(Vector3.forward.x * speedForward_, heroRb_.velocity.y, Vector3.forward.z * speedForward_);
        // hero_.transform.position += Vector3.forward * speedForward_ * Time.deltaTime;

        heroRb_.AddForce(Vector3.down*9.8f*gravityScale_,ForceMode.Acceleration);
    }
}
