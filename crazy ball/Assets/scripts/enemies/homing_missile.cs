using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homing_missile : MonoBehaviour
{
    // damages of the missiles
    [HideInInspector] public int damage1 = Gun_Container.missile1.GetDamage();
    [HideInInspector] public int damage2 = Gun_Container.missile2.GetDamage();
    [SerializeField] private GameObject player;
    private Rigidbody2D rb_missile;

    [SerializeField] private float rotate_speed = 200f;
    [SerializeField] private float speed = 5f;
    private void Start() {
        player = GameObject.Find("player");
        rb_missile = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate() {
        if(player!=null){
        Vector3 direction = player.transform.position - transform.position;
        Vector3 current_dir = transform.up;
        direction.Normalize();
        float rotate_amount = Vector3.Cross(direction, current_dir).z;

        rb_missile.angularVelocity = -rotate_amount*rotate_speed;
        rb_missile.velocity = transform.up * speed;
        }
    }
    
    [SerializeField] AudioClip missile_destroying;
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "player bullet" || other.gameObject.tag == "Player"){
            if(gameObject.tag == "missile1"){
                ParticleSystem effect = Instantiate(GameObject.Find("particleManager").GetComponent<particleSystemManager>().missile1_destroy, transform.position, Quaternion.identity);
                MusicManager.instance.Play(missile_destroying);
                    effect.Play();
                    Destroy(gameObject);
            }
            if(gameObject.tag == "missile2"){
                MusicManager.instance.Play(missile_destroying);
                ParticleSystem effect = Instantiate(GameObject.Find("particleManager").GetComponent<particleSystemManager>().missile2_destroy, transform.position, Quaternion.identity);
                    effect.Play();
                    Destroy(gameObject);
            }
            
        }
        
    }
}
