using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_follow : MonoBehaviour
{
    [SerializeField]
    public GameObject player;

    public Vector3 camPos;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if(player == null){
            transform.position = camPos;
        }
        else{
            transform.position = player.transform.position + new Vector3(0, 0, -10);
            camPos = transform.position; // giving camPos the last known position of the camera
        }

    }


}
