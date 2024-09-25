using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health_up : MonoBehaviour
{
    private Rigidbody2D health_up_rb;
    [SerializeField] private float rotation_magnitude;
    private void Start()
    {
        health_up_rb = gameObject.GetComponent<Rigidbody2D>();
        
    }
}
