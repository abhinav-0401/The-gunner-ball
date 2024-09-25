using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homing_missle_spawner : MonoBehaviour
{
    [SerializeField] GameObject[] missiles;
    private float xmin , xmax , ymin , ymax ;

    // delay between 2 spawns;
    private float timeStamp = 0f;
    private float delay = 10f;
    Vector2 coordinate;

    private float total_missiles_to_spawn_in_gameplay = 0;
    private float total_missiles_to_spawn_at_start = 2;
    private void Start() {
        xmin = transform.position.x-1;
        xmax = transform.position.x+1;
        ymin = transform.position.y-1;
        ymax = transform.position.y+1;
        missile_spawner(total_missiles_to_spawn_at_start);    
    }
    private void Update() {
        if(Time.time>=timeStamp){
            missile_spawner(total_missiles_to_spawn_in_gameplay);
        }

        
    }

    private void missile_spawner(float n)
    {

        // Debug.Log("Unity is working properly");
        timeStamp = Time.time + delay;
        total_missiles_to_spawn_in_gameplay+=1;
        int i = 0;
        while (i < n)
        {
            float x = Random.Range(xmin, xmax);
            float y = Random.Range(ymin, ymax);
            coordinate = new Vector3(x, y, 0);
            int rand = Random.Range(0, missiles.Length);
            Instantiate(missiles[rand], coordinate, Quaternion.identity);
            i++;
        }

    }

}
