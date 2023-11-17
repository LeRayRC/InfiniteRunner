using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera camera_;
    public GameObject ship_;
    Vector3 mousePos_;
    Vector3 worldPos_;
    Transform shipTr_;
    void Start()
    {
        shipTr_ = ship_.GetComponent<Transform>();


    }

    // Update is called once per frame
    void Update()
    {   
        mousePos_ = Input.mousePosition;
        worldPos_ = camera_.ScreenToWorldPoint(mousePos_);
        worldPos_.x = Mathf.Clamp(worldPos_.x, camera_.ViewportToWorldPoint(Vector2.zero).x , camera_.ViewportToWorldPoint(Vector2.one).x);
        worldPos_.y = Mathf.Clamp(worldPos_.y, camera_.ViewportToWorldPoint(Vector2.zero).y , camera_.ViewportToWorldPoint(new Vector2(0.4f,0.4f)).y);
        // Debug.Log();
        shipTr_.position = Vector3.Lerp(shipTr_.position,new Vector3(worldPos_.x, worldPos_.y, ship_.transform.position.z), 0.01f);

    }
}
