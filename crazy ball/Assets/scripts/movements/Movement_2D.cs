using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_2D : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    float timestamp = 0f;
    float speedUp_duration = 5f;
    bool speedUp_active;
    public float runSpeed;

    // joystick
    public Joystick joystick;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        // Gives a value between -1 and 1

        // horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        // vertical = Input.GetAxisRaw("Vertical"); // -1 is down
        horizontal = joystick.Horizontal;
        vertical = joystick.Vertical;
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        
        // checking if speedUp powerup is active or not otherwise the original speed will be reduced after every timestamp
        if(speedUp_active==true){
            if(Time.time >= timestamp){
                Return_normal_speed();
            }
        }    
    }

    // everything on speedup powerup
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Speed Up" && speedUp_active == false){
            speedUp_active = true;
            LeanTween.scale(other.gameObject, new Vector3(0.1f, 0.1f, 0), 1f).setEaseOutElastic();
            ParticleSystem effect = Instantiate(GameObject.Find("particleManager").GetComponent<particleSystemManager>().speed_up_effect, other.transform.position, Quaternion.identity);
            effect.Play();
            Destroy(other.gameObject, 1f);
            runSpeed*=2f;
            timestamp = Time.time + speedUp_duration;
        }
    }
    void Return_normal_speed(){
        runSpeed/=2f;
        speedUp_active=false;
    }
    // everything on speedup powerup
    
}
