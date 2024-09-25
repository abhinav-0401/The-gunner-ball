using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class health_bar : MonoBehaviour
{
    public Slider slider;

    // public Transform parent_to_follow;
    public void SetMaxHealth(float health){
        slider.maxValue = health;
        slider.value = health;
    }

    public void setHealth(float health){
        slider.value = health;
    }

    
}
