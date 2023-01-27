using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private bool hasEntered=false;
    
    void OnCollisionEnter(Collision coll){
            // Check for Player Punch
        if ((coll.gameObject.tag == "Player") && (coll.gameObject.GetComponent<SphereCollider>().enabled==true) && (!hasEntered)){
            hasEntered=true;
            gameObject.GetComponent<Animator>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled=false;
            coll.gameObject.GetComponent<SphereCollider>().enabled=false;
            Destroy(gameObject,4f);
             coll.gameObject.GetComponent<PlayerPower>().setPowerCount();
        }
    }  
}
