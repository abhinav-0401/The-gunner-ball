using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class point_system : MonoBehaviour
{
    public static point_system instance;
    public float point_count = 0;
    
    private void Awake() {
        Makesingleton();
        
    }
    
    void Makesingleton(){
        if(instance!=null){
            Destroy(gameObject);
        }
        else{
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }
    
}
