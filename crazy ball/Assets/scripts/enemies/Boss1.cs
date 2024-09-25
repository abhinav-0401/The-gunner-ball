using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    private Rigidbody2D Boss1Rb; // access to rigidbody for adding angular velocity
    [SerializeField] private float revolvingSpeed; // angular velocity given to the circle

    [SerializeField] private GameObject bullet_prefab;

    // time delay between the bullets
    private float timestamp = 0.0f;
    [SerializeField] private float DelayPerShot;
    // time delay between the bullets

    [SerializeField] private float bullet_speed; // speed of the bullets

    // health system of the boss
    private float Currenthealth = healths.Boss1Health;
    private float Maxhealth = healths.Boss1Health;
    // health system of the boss

    // random motion of the boss
    [SerializeField] float random_movespeed = 5f;
    // random motion of the boss
    
    private void Start()
    {
        bullet_speed = Gun_Container.Boss1Gun.GetSpeed();
        DelayPerShot = Gun_Container.Boss1Gun.GetFireRate();
        Boss1Rb = GetComponent<Rigidbody2D>();

        Boss1Rb.angularVelocity = revolvingSpeed;
        // random motion of the boss
        // move_random();

    }
    
    private void FixedUpdate()
    {
        if (Time.time > timestamp)
        {
            BossGunFiring();
        }
        
        // LeanTween.rotateAround(gameObject, Vector3.up, 100, 1);
       
    }
    // firing system of the guns in boss 1. Very similar to the every gun in the game
    void BossGunFiring()
    {
        timestamp = Time.time + DelayPerShot;
        foreach (Transform child in this.transform)
        {
            GameObject gunOnBoss = child.gameObject;
            Transform shootpoint = gunOnBoss.transform.GetChild(0).transform;
            Vector2 dir = (Vector2)shootpoint.position - (Vector2)gunOnBoss.transform.position;
            dir.Normalize();
            GameObject bullet = Instantiate(bullet_prefab, shootpoint.position, Quaternion.identity);
            ParticleSystem smoke_effect = Instantiate(GameObject.Find("particleManager").GetComponent<particleSystemManager>().bullet_smoke, shootpoint.position, Quaternion.identity);
            smoke_effect.Play();
            bullet.GetComponent<bullet>().damage = Gun_Container.Boss1Gun.GetDamage();
            bullet.GetComponent<Rigidbody2D>().velocity = dir * bullet_speed;
        }
    }
    // firing system of the guns in boss 1. Very similar to the every gun in the game

    // Boss damage
    [SerializeField] AudioClip boss_destroy;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "player bullet")
        {
            Currenthealth -= other.gameObject.GetComponent<bullet>().damage;
            point_system.instance.point_count+=other.gameObject.GetComponent<bullet>().damage * 10;
            print(point_system.instance.point_count);
            if (Currenthealth <= 0)
            {
                MusicManager.instance.Play(boss_destroy);
                ParticleSystem effect = Instantiate(GameObject.Find("particleManager").GetComponent<particleSystemManager>().boss1_destruction, transform.position, Quaternion.identity);
                effect.Play();
                basic_enemy_spawner.enemy_spawn_active = true;
                Destroy(gameObject);
            }
        }
        
    }
    // Boss damage

    private void move_random(){
        float x,y;
        x = Random.Range(-2,2);
        y = Random.Range(-2,2);
        Vector2 random_dir = new Vector2(x,y);

        Boss1Rb.velocity = random_dir * random_movespeed;
    }
}
