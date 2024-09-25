using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup_spawner : MonoBehaviour
{
    [SerializeField] GameObject[] powerups;
    private float xmin = -20f, xmax = 20f, ymin = -20f, ymax = 20f;
    Vector2 coordinate;

    // delay between two spawns
    float timestamp = 0f;
    float delay = 10f;
    private void Update()
    {
        if (Time.time >=timestamp)
        {
            powerup_spawn();
        }
    }
    void powerup_spawn()
    {
        timestamp = Time.time + delay;
        for (int i = 0; i < powerups.Length; i++)
        {
            float x = Random.Range(xmin, xmax);
            float y = Random.Range(ymin, ymax);
            coordinate = new Vector2(x, y);
            int rand = Random.Range(0, powerups.Length);
            GameObject power_up_clone = Instantiate(powerups[rand], coordinate, Quaternion.identity);
            power_up_clone.GetComponent<Rigidbody2D>().angularVelocity = 150f;

        }
    }
}
