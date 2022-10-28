using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpList : MonoBehaviour
{
    // Powerups
    public GameObject Armor;
    public GameObject Invincible;
    public GameObject JumpHigher;
    public GameObject PointsMultiplier;
    public GameObject SlowTime;
    public GameObject TeleportForward;

    public static List<GameObject> powerups;

    public void Start(){
        powerups = new List<GameObject>();
        powerups.Add(Armor);
        powerups.Add(Invincible);
        powerups.Add(JumpHigher);
        powerups.Add(PointsMultiplier);
        powerups.Add(SlowTime);
        powerups.Add(TeleportForward);
    }
}
