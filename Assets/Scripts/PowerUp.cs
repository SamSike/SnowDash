using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float multiplier = 4f;

    public float Jumpfactor = 2f;
    public float duration = 8f;
    public float Invincibility_duration = 15f;
    public GameObject pickupEffect;
    public Player Sled_1;
    void OnTriggerEnter (Collider other){
        if(other.CompareTag("Player")){
            StartCoroutine(pickUp(other));
        }
    }

    void teleport(Collider player){
        Debug.Log("Power Up is Teleport");
        Debug.Log(Sled_1.GetZSpeed());
        float boostedspeed = Sled_1.GetZSpeed() * multiplier;
        Sled_1.SetZspeed(boostedspeed);
        Debug.Log(Sled_1.GetZSpeed());
    }

    void jumpBoost(Collider player){
        Debug.Log("Power Up is Jump Higher");
        Sled_1.SetyMove(2 * Jumpfactor);
    }

    void invinsible(Collider player){
        Debug.Log("Power Up is Invincible");
        Sled_1.Setinvincible(true);
    }

    void buildarmor(Collider player){
        Debug.Log("Power Up is Armor");
        Sled_1.Setarmorcount((Sled_1.GetArmorCount()) + 2);
    }

    IEnumerator pickUp(Collider player){
        var effect = Instantiate(pickupEffect, transform.position, transform.rotation);
        bool teleporting = false;
        bool jumpboost = false;
        bool isinvinsible = false;
        int armorcount = 0;

        Debug.Log(this.name);
        if(this.name == "Armor"){
            //Add Armor to Player.
            buildarmor(player);
            Debug.Log(Sled_1.GetArmorCount());           
            armorcount += 1;

            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
        }

        if(this.name == "Invincible"){
            //Add Invincibility to Player.
            if(isinvinsible == false){
                invinsible(player);
            }
            isinvinsible = true;
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;

            yield return new WaitForSeconds(Invincibility_duration);

            if(isinvinsible == true){
                Sled_1.Setinvincible(false);
                isinvinsible = false;
            }
        }

        if(this.name == "JumpHigher"){
            //Add Jump Boost to Player.
            if(jumpboost == false){
                jumpBoost(player);
            }
            jumpboost = true;
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;

            yield return new WaitForSeconds(duration);

            if(jumpboost == true){
                Sled_1.SetyMove(Sled_1.GetyMove()/Jumpfactor);
                jumpboost = false;
            }
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
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;

            yield return new WaitForSeconds(duration);

            if(teleporting == true){
                Sled_1.SetZspeed((Sled_1.GetZSpeed()) / multiplier);
                teleporting = false;
                
            }
        }

        Destroy(effect);
        Destroy(gameObject);
    }

}   
