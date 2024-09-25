using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [HideInInspector]
    public float damage;
    [SerializeField]private Camera cam;

    public float magnitude;

    private void Awake()
    {
        // cam = FindObjectOfType<Camera>();
        // cam = GameObject.FindWithTag("MainCamera").Camera;
        foreach(Camera c in Camera.allCameras){
            if(c.name == "Main Camera"){
                cam = c;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        StartCoroutine(cam.GetComponent<Camera_Shake>().Shake(magnitude));
        bullet_destroy_effect();
        Destroy(gameObject);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        StartCoroutine(cam.GetComponent<Camera_Shake>().Shake(magnitude));
        bullet_destroy_effect();
        Destroy(gameObject);
    }

    private void Update()
    {
        Destroy(gameObject, 2f);
    }

    // for the bullet destruction effect
    private void bullet_destroy_effect()
    {
        if (transform.tag == "player bullet")
        {
            ParticleSystem effect = Instantiate(GameObject.Find("particleManager").GetComponent<particleSystemManager>().player_bullet_hit, transform.position, Quaternion.identity);
            effect.Play();
        }
        else if (transform.tag == "boss1bullet")
        {
            ParticleSystem effect = Instantiate(GameObject.Find("particleManager").GetComponent<particleSystemManager>().boss1_bullet_hit, transform.position, Quaternion.identity);
            effect.Play();
        }
    }
    // for the bullet destruction effect
}
