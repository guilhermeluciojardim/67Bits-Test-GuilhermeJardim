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
            coll.gameObject.GetComponent<PlayerPower>().setPowerCount();
            coll.gameObject.GetComponent<SphereCollider>().enabled=false;
            Destroy(gameObject,4f);
            Debug.Log("acertou");
        }
    }  
}
