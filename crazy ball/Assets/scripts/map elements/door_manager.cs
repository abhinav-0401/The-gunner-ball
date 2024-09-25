using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class door_manager : MonoBehaviour
{
    [SerializeField] TMP_Text target_score_text;
    private float target_score = 100f;
    // RaycastHit2D crossing_check;
    // public static bool door_open = false;
    // [SerializeField] private Collider2D checker;
    private void Start() {
        target_score_text.text = target_score.ToString();
        // crossing_check = Physics2D.Raycast(new Vector2(transform.position.x ,transform.position.y - 2.5f), -transform.up);
    }
    private void Update() {
        if(point_system.instance.point_count >= target_score){
            // door_open = true;
            // gameObject.GetComponent<Collider2D>().enabled = false;
            transform.LeanMoveLocalY(6f, 1f);
            target_score+=5000f;
        }
    }
    
    
}
