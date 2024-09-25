using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun_aim : MonoBehaviour
{


    //for gun aim
    [HideInInspector]
    public Vector2 dir_vector;
    private float target_angle;
    public Joystick aim_joystick;
    Rigidbody2D gun_rb;
    [SerializeField]
    // private float time = 100f;
    // gun aim
    void Start()
    {
        gun_rb = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        float horizontal = aim_joystick.Horizontal;
        float vertical = aim_joystick.Vertical;
        // Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Vector2 dir = (Vector2)transform.position - mousePos;
        Vector2 dir = new Vector2(horizontal, vertical);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

    }
}
