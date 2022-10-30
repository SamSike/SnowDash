using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float multiplier = 4f;

    public float Jumpfactor = 2f;
    public float duration = 5f;
    public GameObject pickupEffect;
    public Player players;
    void OnTriggerEnter (Collider other){
        if(other.CompareTag("Player")){
            StartCoroutine(pickUp(other));
        }
    }

    void teleport(Collider player){
        Debug.Log("Power Up is Teleport");
        Debug.Log(players.GetZSpeed());
        float boostedspeed = players.GetZSpeed() * multiplier;
        players.SetZspeed(boostedspeed);
        Debug.Log(players.GetZSpeed());
    }

    void jumpBoost(Collider player){
        Debug.Log("Power Up is Jump Higher");
        players.SetyMove(2 * Jumpfactor);
    }

    void invinsible(Collider player){
        Debug.Log("Power Up is Invincible");
        players.Setinvincible(true);
    }

    IEnumerator pickUp(Collider player){
        var effect = Instantiate(pickupEffect, transform.position, transform.rotation);
        bool teleporting = false;
        bool jumpboost = false;
        bool isinvinsible = false;

        Debug.Log(this.name);
        if(this.name == "Armor"){
            //Add Armor to Player.
            Debug.Log("Power Up is Armor");
        }
        if(this.name == "Invincible"){
            //Add Invincibility to Player.
            if(isinvinsible == false){
                invinsible(player);
            }
            isinvinsible = true;
        }
        if(this.name == "JumpHigher"){
            //Add Jump Boost to Player.
            if(jumpboost == false){
                jumpBoost(player);
            }
            jumpboost = true;
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
            if(teleporting == false){
                teleport(player);
            }             
            teleporting = true; 
        }


        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(duration);

        if(teleporting == true){
            players.SetZspeed((players.GetZSpeed()) / multiplier);
            teleporting = false;
        }

        if(jumpboost == true){
            players.SetyMove(players.GetyMove()/Jumpfactor);
            jumpboost = false;
        }

        if(isinvinsible == true){
            players.Setinvincible(false);
            isinvinsible = false;
        }
        
        Destroy(effect);
        Destroy(gameObject);
    }

}   
