using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float multiplier = 1f;
    public float duration = 4f;
    public GameObject pickupEffect;
    void OnTriggerEnter (Collider other){
        if(other.CompareTag("Player")){
            StartCoroutine(pickUp(other));
        }
    }

    IEnumerator pickUp(Collider player){
        Instantiate(pickupEffect, transform.position, transform.rotation);

        if(this.name == "Armor"){
                //Add Armor to Player.
                Debug.Log("Power Up is Armor");
            }
            if(this.name == "Invicible"){
                //Add Invisibility to Player.
                Debug.Log("Power Up is Invisible");
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
                Debug.Log("Power Up is Teleport");
            }

        //player.transform.localScale *= multiplier;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(duration);
        //player.transform.localScale /= multiplier;
        Destroy(gameObject);
    }

}   
