using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Gun_Container 
{
    public static Gun Pistol = new Gun(0.2f, 1, 0.0f, 22f, 2, "Pistol");
    public static Gun revolver = new Gun(0.4f, 2,0.4f, 24f, 2, "Revolver");
    public static Gun Shotgun = new Gun(0.55f, 6, 0.35f, 24f, 1, "Shotgun");
    
    public static Gun canon = new Gun(0.5f, 1, 0.0f, 10f, 4,"Canon");

    public static Gun enemyGun = new Gun(0.4f, 1, 0.0f, 10f, 2, "EnemyGun");    

    public static Gun Boss1Gun = new Gun(0.2f, 1, 0f, 5f, 2, "Boss1Gun");
    public static Gun Boss2Projectile = new Gun(1f, 1, 0, 10f, 10, "Boss2Projectile");

    public static Gun missile1 = new Gun(0f,0f, 0f,0f,10,"Missile1");
    public static Gun missile2 = new Gun(0f,0f, 0f,0f,15,"Missile2");
}
