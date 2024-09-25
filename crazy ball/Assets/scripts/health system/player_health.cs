using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class player_health : MonoBehaviour
{
    // for adding health bar
    public float MaxHealth;
    public float currentHealth;
    public health_bar playerBar;
    // for adding health bar
    float timestamp = 0.0f;
    [SerializeField] AudioClip player_hit;
    [SerializeField] AudioClip player_destroy;
    bool player_alive = true;
    [SerializeField] gameOverScreen gameoverscreen;
    private void Start()
    {

        MaxHealth = healths.playerHealth;
        currentHealth = healths.playerHealth;
        playerBar.SetMaxHealth(MaxHealth);
    }
    private void Update()
    {
        if (player_alive == false)
        {
            float hs = PlayerPrefs.GetFloat("HighScore");
            if (point_system.instance.point_count > hs)
            {
                hs = point_system.instance.point_count;
                PlayerPrefs.SetFloat("HighScore", hs);
            }
            MusicManager.instance.Play(player_destroy);
            gameoverscreen.setup();
        }
    }

    // player damage block
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "canon bullet")
        {
            MusicManager.instance.Play(player_hit);
            currentHealth -= other.gameObject.GetComponent<canon_bullet>().damage;
            playerBar.setHealth(currentHealth);//updating the fill of the health bar
            print("player currenthealth: " + currentHealth);
            if (currentHealth <= 0)
            {
                ParticleSystem effect = Instantiate(GameObject.Find("particleManager").GetComponent<particleSystemManager>().player_destruction, transform.position, Quaternion.identity);
                effect.Play();
                player_alive = false;
                Destroy(gameObject, 0.1f);
            }
        }
        if (other.gameObject.tag == "mobile enemy bullet")
        {
            MusicManager.instance.Play(player_hit);
            currentHealth -= other.gameObject.GetComponent<canon_bullet>().damage;
            playerBar.setHealth(currentHealth);//updating the fill of the health bar
            print("player currenthealth: " + currentHealth);
            if (currentHealth <= 0)
            {
                ParticleSystem effect = Instantiate(GameObject.Find("particleManager").GetComponent<particleSystemManager>().player_destruction, transform.position, Quaternion.identity);
                effect.Play();
                player_alive = false;
                Destroy(gameObject, 0.1f);
            }
        }
        if (other.gameObject.tag == "projectile")
        {
            MusicManager.instance.Play(player_hit);
            currentHealth -= other.gameObject.GetComponent<projectile>().projectileDamage;
            playerBar.setHealth(currentHealth);//updating the fill of the health bar
            print("player currenthealth: " + currentHealth);
            if (currentHealth <= 0)
            {
                ParticleSystem effect = Instantiate(GameObject.Find("particleManager").GetComponent<particleSystemManager>().player_destruction, transform.position, Quaternion.identity);
                effect.Play();
                player_alive = false;
                Destroy(gameObject, 0.1f);
            }
        }
        if (other.gameObject.tag == "boss1bullet")
        {
            MusicManager.instance.Play(player_hit);
            currentHealth -= other.gameObject.GetComponent<bullet>().damage;
            playerBar.setHealth(currentHealth);//updating the fill of the health bar
            print("player currenthealth: " + currentHealth);
            // print(currentHealth);
            if (currentHealth <= 0)
            {
                ParticleSystem effect = Instantiate(GameObject.Find("particleManager").GetComponent<particleSystemManager>().player_destruction, transform.position, Quaternion.identity);
                effect.Play();
                player_alive = false;
                Destroy(gameObject, 0.1f);
            }
        }
        if (other.gameObject.tag == "missile1" || other.gameObject.tag == "missile2")
        {
            if (other.gameObject.tag == "missile1")
            {
                MusicManager.instance.Play(player_hit);
                currentHealth -= other.gameObject.GetComponent<homing_missile>().damage1;
                print("player currenthealth: " + currentHealth);
                playerBar.setHealth(currentHealth);//updating the fill of the health bar
                if (currentHealth <= 0)
                {
                    ParticleSystem effect = Instantiate(GameObject.Find("particleManager").GetComponent<particleSystemManager>().player_destruction, transform.position, Quaternion.identity);
                    effect.Play();
                    player_alive = false;
                    Destroy(gameObject, 0.1f);
                }
            }
            if (other.gameObject.tag == "missile2")
            {
                MusicManager.instance.Play(player_hit);
                currentHealth -= other.gameObject.GetComponent<homing_missile>().damage2;
                playerBar.setHealth(currentHealth);//updating the fill of the health bar
                print("player currenthealth: " + currentHealth);
                if (currentHealth <= 0)
                {
                    ParticleSystem effect = Instantiate(GameObject.Find("particleManager").GetComponent<particleSystemManager>().player_destruction, transform.position, Quaternion.identity);
                    effect.Play();
                    player_alive = false;
                    Destroy(gameObject, 0.1f);
                }
            }
        }
    }
    // player damage block

    // health up power up implementation
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "health up pill")
        {
            // Debug.Log(currentHealth);
            if (currentHealth > 80 && currentHealth < MaxHealth)
            {
                float health_up = MaxHealth - currentHealth;
                currentHealth += health_up;
                print("player currenthealth: " + currentHealth);
                playerBar.setHealth(currentHealth);//updating the fill of the health bar
            }
            else if (currentHealth <= 80)
            {
                currentHealth += 20;
                print("player currenthealth: " + currentHealth);
                playerBar.setHealth(currentHealth);//updating the fill of the health bar
            }
            Debug.Log(currentHealth);
            ParticleSystem effect = Instantiate(GameObject.Find("particleManager").GetComponent<particleSystemManager>().health_up_effect, other.transform.position, Quaternion.identity);
            effect.Play();
            Destroy(other.gameObject);
        }
    }
    // health up power up implementation
}
