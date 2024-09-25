using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomMapGenerator : MonoBehaviour
{
    //map genration 
    [SerializeField]
    private GameObject obstacle;
    [SerializeField]
    private float obstacle_count = 10;

    //coordinate range for the obstackle
    private float xmin = -50;
    private float xmax = 50;
    private float ymax = 60;
    private float ymin = -5;

    //coordinate range for the obstackle

    [SerializeField]
    private float radius = 4; //radius to remove overlapping and close obstacles for even distribution

    Vector3 coordinate; //coordinate for every obstacle
    //map generation
    void Start()
    {
        mapgenerator();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Debug.Log(Input.mousePosition);
        }


    }
    private void mapgenerator()
    {

        Debug.Log("Unity is working properly");
        int i = 0;
        while (i < obstacle_count)
        {
            float x = Random.Range(xmin, xmax);
            float y = Random.Range(ymin, ymax);
            coordinate = new Vector3(x, y, 0);
            Collider2D[] close_ones = Physics2D.OverlapCircleAll((Vector2)coordinate, radius);
            if (close_ones.Length == 0)
            {
                
                Instantiate(obstacle, coordinate, obstacle.transform.rotation);
            }
            else
            {
                for (int j = 0; j < close_ones.Length; j++)
                {
                    if (close_ones[j].gameObject.layer == 3)
                    {
                        Destroy(close_ones[j].gameObject);
                        i--;
                    }
                }
            }
            i++;
        }

    }
}
