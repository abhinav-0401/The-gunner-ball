using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canon_bullet : MonoBehaviour
{
    
    public float damage;
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.tag == "Player" || other.collider.tag == "Shield"){
            // bullet destruction effect
            ParticleSystem effect = Instantiate(GameObject.Find("particleManager").GetComponent<particleSystemManager>().canon_and_enemy_bullet_hit, transform.position, Quaternion.identity);
            effect.Play();
            Destroy(gameObject);   
        }       
    }

    private void Update() {
        Destroy(gameObject,3f);
    }
}
