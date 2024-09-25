using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield : MonoBehaviour
{
    
    [SerializeField] GameObject player;

    // for the time period of sheild
    float currentTime=0f;
    Vector3 shieldPos;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        // gameObject.SetActive(false);
    }
    

    private void Update()
    {

        if (player == null)
        {
            transform.position = shieldPos;
        }
        else
        {
            transform.position = player.transform.position;
            shieldPos = transform.position; // giving shieldPos the last known position of the camera
        }

        currentTime+=Time.deltaTime;
        // time period block
        if(currentTime>=10f){
            // shield closing animation
            
            LeanTween.scale(gameObject, new Vector3(0.35f,0.35f,0), 1.5f).setEaseOutExpo();
            
            // shield closing animation
            Destroy(gameObject,0.2f);
        }
        // time period block
    }

    // shield follow block

    // shield interaction block
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "canon bullet" || other.gameObject.tag == "mobile enemy bullet" || other.gameObject.tag == "boss1bullet" || other.gameObject.tag == "projectile")
        {
            Destroy(other.gameObject);
        }

    }
    // shield interaction block

    

}
