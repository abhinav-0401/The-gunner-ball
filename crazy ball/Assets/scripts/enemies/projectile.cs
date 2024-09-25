using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public float projectileDamage;
    private void Start() {
        projectileDamage = Gun_Container.Boss2Projectile.GetDamage();
    }
    
}
