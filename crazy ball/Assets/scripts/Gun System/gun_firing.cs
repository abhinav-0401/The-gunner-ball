using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun_firing : MonoBehaviour
{

    private Gun gun; // the gun object with its features 
    Gun[] gun_list = { Gun_Container.Pistol, Gun_Container.Shotgun, Gun_Container.revolver }; // list of all the guns
    public GameObject bullet_prefab; // actual prefab for the bullet
    [SerializeField] private Transform Nozzle; // the point where the bullet will be instantiated

    [SerializeField] AudioClip firing_sound; // firing sound effect

    // bullet aim joystick
    public Joystick bullet_aim_joystick;
    float horizontal = 0;
    float vertical = 0;
    //for adding a delay between firing of bullets
    private float timestamp = 0.0f;
    private float perShotDelay; // fireRate argument of gun object will given to this
    //for adding a delay between firing of bullets


    private float gunChange_timestamp = 0f;
    private float gunChange_timeperiod = 10f;
    private bool gunChange_active;

    // gun change sounds
    private void Start()
    {

        gun = gun_list[0]; // assigning the created gun object a gun from the Gun_Container class
        perShotDelay = gun.GetFireRate();


    }
    private void Update()
    {
        horizontal = bullet_aim_joystick.Horizontal;
        vertical = bullet_aim_joystick.Vertical;
        if (Time.time > timestamp)
        {
            if (horizontal != 0 || vertical != 0)
            {
                Fire(gun);
            }

        }

        if (gunChange_active == true)
        {
            if (Time.time >= gunChange_timestamp)
            {
                gun = gun_list[0];
            }
        }
    }

    // firing of bullets function 

    private void Fire(Gun gun)
    {
        // Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        // Vector2 dir = mousePos - (Vector2)Nozzle.position;
        Vector2 dir = new Vector2(horizontal, vertical);
        dir.Normalize();
        for (int i = 0; i < gun.GetBullets(); i++)
        {
            timestamp = Time.time + perShotDelay;
            GameObject bullet = Instantiate(bullet_prefab, Nozzle.position, Quaternion.identity);
            MusicManager.instance.Play(firing_sound);
            // smoke effect particle effect
            ParticleSystem smoke_effect = Instantiate(GameObject.Find("particleManager").GetComponent<particleSystemManager>().bullet_smoke, Nozzle.position, Quaternion.identity);
            smoke_effect.Play();
            // smoke effect particle effect

            float speed = gun.GetSpeed();
            Vector2 pdir = Vector2.Perpendicular(dir) * Random.Range(-gun.GetSpread(), gun.GetSpread());
            bullet.GetComponent<Rigidbody2D>().AddForce((dir + pdir) * gun.GetSpeed(), ForceMode2D.Impulse);

            bullet.GetComponent<bullet>().damage = gun.GetDamage();

        }
    }
    // firing of bullets function

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Shotgun")
        {
            gunChange_timestamp = Time.time + gunChange_timeperiod;
            gunChange_active = true;
            gun = gun_list[2];
            ParticleSystem effect = Instantiate(GameObject.Find("particleManager").GetComponent<particleSystemManager>().shotgun_effect, other.transform.position, Quaternion.identity);
            effect.Play();
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "MachineGun")
        {
            gunChange_timestamp = Time.time + gunChange_timeperiod;
            gunChange_active = true;
            gun = gun_list[1];
            ParticleSystem effect = Instantiate(GameObject.Find("particleManager").GetComponent<particleSystemManager>().machine_gun_effect, other.transform.position, Quaternion.identity);
            effect.Play();
            Destroy(other.gameObject);
        }
    }
}