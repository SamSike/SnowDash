using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float multiplier = 7f;
    public float duration = 4f;
    public GameObject pickupEffect;
    public Player players;

    bool teleporting = false;
    void OnTriggerEnter (Collider other){
        if(other.CompareTag("Player")){
            StartCoroutine(pickUp(other));
        }
    }

    void teleport(Collider player){
        Debug.Log("Power Up is Teleport");
        players.SetZspeed((players.GetZSpeed()) * multiplier);
    }

    IEnumerator pickUp(Collider player){
        var effect = Instantiate(pickupEffect, transform.position, transform.rotation);

        if(this.name == "Armor"){
            //Add Armor to Player.
            Debug.Log("Power Up is Armor");
        }
        if(this.name == "Invincible"){
            //Add Invincibility to Player.
            Debug.Log("Power Up is Invincible");
        }
        if(this.name == "JumpHigher"){
            //Add Jump Boost to Player.
            Debug.Log("Power Up is Jump Higher");
        }
        if(this.name == "PointsMultiplier"){
            //Add Points Multiplier to Player.
            Debug.Log("Power Up is Multiply Points");
        }
        if(this.name == "SlowTime"){
            //Slow Time to Player.
            Debug.Log("Power Up is Slow Time");
        }
        if(this.name == "TeleportForward"){
            //Add Speed Boost to Player.
            teleport(player);
            teleporting = true; 
        }


        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(duration);

        if(teleporting == true){
            players.SetZspeed((players.GetZSpeed()) / multiplier);
            teleporting = false;
        }

        Destroy(effect);
        Destroy(gameObject);
    }

}   
