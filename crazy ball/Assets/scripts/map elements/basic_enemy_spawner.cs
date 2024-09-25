using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basic_enemy_spawner : MonoBehaviour
{
    // list of enemies;
    [SerializeField] GameObject[] enemy_list;
    private float xmin = -20f, xmax = 20f, ymin = -20f, ymax = 20f;
    private int total_enemies_to_spawn_at_start = 3;
    private int total_enemies_to_spawn_in_gameplay = 0;
    Vector2 coordinate;
    
    public static bool enemy_spawn_active = true;
    // timer
    private float timeStamp = 0.0f;
    private float timeStamp2 = 60f;
    private float delay_between_two_spawns = 10f;
    private float delay_between_two_boss_spawns = 60f;
    // timer 
    [SerializeField] GameObject[] boss_list;
    // private float xmin = -20f, xmax = 20f, ymin = -20f, ymax = 20f;
    
    private void Start()
    {
        enemy_spawner(total_enemies_to_spawn_at_start);
    }

    private void Update() {
        if(Time.time>=timeStamp && enemy_spawn_active){
            enemy_spawner(total_enemies_to_spawn_in_gameplay + total_enemies_to_spawn_at_start);
        }
        if(Time.time>=timeStamp2){
            boss_spawner(1);
            enemy_spawn_active = false;
        }
    }
    private void enemy_spawner(float n)
    {

        // Debug.Log("Unity is working properly");
        timeStamp = Time.time + delay_between_two_spawns;
        total_enemies_to_spawn_in_gameplay+=1;
        int i = 0;
        while (i < n)
        {
            float x = Random.Range(xmin, xmax);
            float y = Random.Range(ymin, ymax);
            coordinate = new Vector3(x, y, 0);
            int rand = Random.Range(0, enemy_list.Length);
            if(enemy_list[rand].tag == "canon"){
                    ParticleSystem effect = Instantiate(GameObject.Find("particleManager").GetComponent<particleSystemManager>().canon_spawn_effects, coordinate, Quaternion.identity);
                    effect.Play();
            }
            if(enemy_list[rand].tag == "mobile enemy"){
                    ParticleSystem effect = Instantiate(GameObject.Find("particleManager").GetComponent<particleSystemManager>().enemy_spawn_effects, coordinate, Quaternion.identity);
                    effect.Play();
            }
            // if(enemy_list[rand].tag == "boss1"){
            //         ParticleSystem effect = Instantiate(GameObject.Find("particleManager").GetComponent<particleSystemManager>().boss1_spawn_effects, coordinate, Quaternion.identity);
            //         effect.Play();
            // }
            // if(enemy_list[rand].tag == "boss2"){
            //         ParticleSystem effect = Instantiate(GameObject.Find("particleManager").GetComponent<particleSystemManager>().boss2_spawn_effects, coordinate, Quaternion.identity);
            //         effect.Play();
            // }

            // Instantiate(enemy_list[rand], coordinate, Quaternion.identity);
            StartCoroutine(delayed_spawn(enemy_list[rand], coordinate));
            i++;
        }

    }
    private void boss_spawner(float n){
        timeStamp2 = Time.time + delay_between_two_boss_spawns;
        int i = 0;
        while(i<n){
            float x = Random.Range(xmin, xmax);
            float y = Random.Range(ymin, ymax);
            coordinate = new Vector3(x, y, 0);
            int rand = Random.Range(0, boss_list.Length);
           
            if(boss_list[rand].tag == "boss1"){
                    ParticleSystem effect = Instantiate(GameObject.Find("particleManager").GetComponent<particleSystemManager>().boss1_spawn_effects, coordinate, Quaternion.identity);
                    effect.Play();
            }
            if(boss_list[rand].tag == "boss2"){
                    ParticleSystem effect = Instantiate(GameObject.Find("particleManager").GetComponent<particleSystemManager>().boss2_spawn_effects, coordinate, Quaternion.identity);
                    effect.Play();
            }

            // Instantiate(enemy_list[rand], coordinate, Quaternion.identity);
            StartCoroutine(delayed_spawn(boss_list[rand], coordinate));
            i++;
        }
    }

    IEnumerator delayed_spawn(GameObject obj, Vector3 coordinate){
        yield return new WaitForSeconds(3f);
        Instantiate(obj, coordinate, Quaternion.identity);
    }

}
