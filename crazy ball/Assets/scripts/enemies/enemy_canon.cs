using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class enemy_canon : MonoBehaviour
{
    [SerializeField] private float currentHealth;

    [SerializeField] private AudioClip enemy_firing_sound, enemy_death;


   
    private GameObject target_player;
    [SerializeField]
    private Transform shootpoint;
    [SerializeField]
    private float looking_Radius = 10f;
    [SerializeField]
    private GameObject canon_bullet_prefab;
    [SerializeField]
    private float canon_bullet_speed;
    [SerializeField]
    private float canon_rotation_speed = 250f;
    //for time delay between each shot of bullet
    private float timestamp = 0.0f;
    private float DelayPerShot;
    //for time delay between each shot of bullet
    Vector2 target_dir;
    [SerializeField]
    private float enemy_rotation_speed = 250f;
    [SerializeField]
    private float enemy_movement_speed = 20f;

    private void Start()
    {
        // for adding health bar
        currentHealth = healths.canonHealth;
        

        target_player = GameObject.FindGameObjectWithTag("Player");// At the start of the game it would assign Player gameobject directly to the target_player so that i don't have to that manually

        // using gun_container class to assign the gun features
        canon_bullet_speed = Gun_Container.canon.GetSpeed();
        DelayPerShot = Gun_Container.canon.GetFireRate();
        // using gun_container class to assign the gun features
     
    }
    private void Update()
    {

        
        if(target_player!=null){
        target_dir = target_player.transform.position - transform.position;

        if (target_dir.magnitude <= looking_Radius && Time.time > timestamp)
        {
            fire_cannon();

        }

        lookAtandMoveTowards(target_dir);
        }
    }

    // for the canon to look at the player 
    private void lookAt()
    {
        float target_angle = Mathf.Atan2(target_dir.y, target_dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, target_angle), canon_rotation_speed * Time.deltaTime);
    }
    // for the canon to look at the player 

    // for the canon to fire bullets
    private void fire_cannon()
    {
        timestamp = DelayPerShot + Time.time;
        GameObject canon_bullet = Instantiate(canon_bullet_prefab, (Vector2)shootpoint.position, Quaternion.identity);
        canon_bullet.GetComponent<canon_bullet>().damage = Gun_Container.canon.GetDamage();
        // MusicManager.instance.Play(enemy_firing_sound);
        // smoke effect particle effect
        ParticleSystem smoke_effect = Instantiate(GameObject.Find("particleManager").GetComponent<particleSystemManager>().bullet_smoke, shootpoint.position, Quaternion.identity);
        smoke_effect.Play();
        // smoke effect particle effect
        Vector2 canon_bullet_direction = target_dir;
        canon_bullet_direction.Normalize();
        canon_bullet.GetComponent<Rigidbody2D>().velocity = canon_bullet_direction * canon_bullet_speed;
    }
    // for the canon to fire bullets

    // to look at the player gameObject ans move towards it
    private void lookAtandMoveTowards(Vector2 target_dir)
    {
        float target_angle = Mathf.Atan2(target_dir.y, target_dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, target_angle), enemy_rotation_speed * Time.deltaTime);
        transform.position = Vector2.MoveTowards(transform.position, target_player.transform.position, enemy_movement_speed * Time.deltaTime);
        // Debug.Log(transform.position);

    }
    // to look at the player gameObject ans move towards it

    // health damage for the canon
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "player bullet")
        {
            currentHealth -= other.gameObject.GetComponent<bullet>().damage;
            point_system.instance.point_count+=other.gameObject.GetComponent<bullet>().damage * 10;
            
            if (currentHealth <= 0)
            {
                MusicManager.instance.Play(enemy_death);
                // just one line for particle system

                ParticleSystem effect = Instantiate(GameObject.Find("particleManager").GetComponent<particleSystemManager>().canon_destruction, transform.position, Quaternion.identity);
                effect.Play();
                // for destroying the particle gameobject stop action setting of particle system is set to destroy

                Destroy(gameObject);
            }
        }
    }
    // health damage for the canon

}
