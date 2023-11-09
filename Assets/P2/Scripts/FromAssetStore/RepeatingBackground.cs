using UnityEngine;

/// <summary>
/// This script attaches to ‘Background’ object, and would move it up if the object went down below the viewport border. 
/// This script is used for creating the effect of infinite movement. 
/// </summary>
public class RepeatingBackground : MonoBehaviour
{
    SpriteRenderer sprite_;
    public Camera camera_;
    float screenMinY;
    float screenMaxY;
    float offset;
    public GameObject partner_;

    public void Start(){
        sprite_ = GetComponent<SpriteRenderer>();
        screenMinY = camera_.ViewportToWorldPoint(new Vector3(0.0f,0.0f,camera_.farClipPlane)).y;
        screenMaxY = camera_.ViewportToWorldPoint(new Vector3(1.0f,1.0f,camera_.farClipPlane)).y;
        offset = sprite_.size.y*0.5f;
        Debug.Log(screenMinY + " |  " + screenMaxY);
        Debug.Log(gameObject.name + " size sprite " + offset);
    }
    
    private void Update()
    {
        if ((transform.position.y + offset) < screenMinY) //if sprite goes down below the viewport move the object up above the viewport
        {
            RepositionBackground();
        }
    }

    void RepositionBackground() 
    {
        float partner_size = partner_.GetComponent<SpriteRenderer>().size.y * 0.5f;
        float partner_pos_y = partner_.GetComponent<Transform>().position.y;
        transform.position = new Vector3(transform.position.x, partner_pos_y + (offset * 2.0f) , transform.position.z);
    }
}
