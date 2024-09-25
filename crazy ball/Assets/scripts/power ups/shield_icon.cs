using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield_icon : MonoBehaviour
{
    [SerializeField] GameObject shield_powerup;
    
    
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            
            GameObject force_sheild = Instantiate(shield_powerup, other.transform.position, Quaternion.identity);
            LeanTween.scale(force_sheild, new Vector3(1.2f, 1.2f, 0f), 1f).setEaseOutElastic(); // elastic popping shield animation
            LeanTween.rotateAround(force_sheild,Vector3.forward,-3600, 10f).setLoopClamp(); // rotation animation

            ParticleSystem effect = Instantiate(GameObject.Find("particleManager").GetComponent<particleSystemManager>().shield_icon_effect, transform.position, Quaternion.identity);
            effect.Play();
            Destroy(gameObject);
        }
    }

    
}
