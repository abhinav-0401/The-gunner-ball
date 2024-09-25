using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class edge_detection : MonoBehaviour
{
    private GameObject player;

    private void Start() {
        player = GameObject.Find("player");
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject == player){
            // gameObject.GetComponentInParent<Transform>().LeanMoveLocalY(0f,1f);
            transform.parent.LeanMoveLocalY(0f,1f);
        }
    }
}
