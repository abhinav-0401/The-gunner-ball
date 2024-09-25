using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class gameOverScreen : MonoBehaviour
{
    public void setup(){
        gameObject.SetActive(true);

    }
    private void Update() {
        if(Input.GetMouseButton(0)){
            point_system.instance.point_count = 0; // restarting the same scene with 0 points
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
