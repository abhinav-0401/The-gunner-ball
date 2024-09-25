using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : MonoBehaviour
{
    private Rigidbody2D Boss2Rb; // access to rigidbody for adding angular velocity
    [SerializeField] private float revolvingSpeed; // angular velocity given to the circle

    // time delay between the projectiles
    private float timestamp = 0.0f;
    [SerializeField] private float DelayPerShot;
    // time delay between the projectiles
    [SerializeField] private float Projectile_speed; // speed of the projectiles

    //health system of the boss
    [SerializeField] private float Currenthealth = healths.Boss2Health;
    [SerializeField] private float Maxhealth = healths.Boss2Health;
    //health system of the boss


    private void Start()
    {
        DelayPerShot = Gun_Container.Boss2Projectile.GetFireRate();
        Projectile_speed = Gun_Container.Boss2Projectile.GetSpeed();
        Boss2Rb = GetComponent<Rigidbody2D>();

        Boss2Rb.angularVelocity = revolvingSpeed;

    }
    private void Update()
    {
        if (Time.time > timestamp)
        {
            BossProjectileFiring();
        }
    }
    // firing system of Boss2
    void BossProjectileFiring()
    {
        timestamp = Time.time + DelayPerShot;
        foreach (Transform child in this.transform)
        {
            GameObject ProjectileOnBoss = Instantiate(child.gameObject, child.transform.position, child.transform.rotation);
            ProjectileOnBoss.transform.localScale = new Vector3(0.6f, 0.6f, 0);
            Vector2 dir = (Vector2)child.gameObject.transform.position - (Vector2)gameObject.transform.position;
            dir.Normalize();
            ProjectileOnBoss.GetComponent<Rigidbody2D>().velocity = dir * Projectile_speed;
            Destroy(ProjectileOnBoss, 2f); // destroying the clone of the projectile child instead of the actual projectile child of boss2
        }
    }
    // firing system of Boss2
    [SerializeField] AudioClip boss_destroy;
    // boss2 damage system
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "player bullet")
        {
            Currenthealth -= other.gameObject.GetComponent<bullet>().damage;
            point_system.instance.point_count += other.gameObject.GetComponent<bullet>().damage * 10;

            if (Currenthealth <= 0)
            {
                MusicManager.instance.Play(boss_destroy);
                ParticleSystem effect = Instantiate(GameObject.Find("particleManager").GetComponent<particleSystemManager>().boss2_destruction, transform.position, Quaternion.identity);
                effect.Play();
                basic_enemy_spawner.enemy_spawn_active = true;
                Destroy(gameObject);
            }
        }
    }
    // boss2 damage system
}
