using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // public GameObject[] pack;
    void OnCollisionEnter(Collision coll){
            // Check for Player Punch
        if ((coll.gameObject.tag == "Player") && (coll.gameObject.GetComponent<SphereCollider>().enabled==true)){
            
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
            gameObject.GetComponent<Rigidbody>().AddForce (Vector3.up * 50f);
            coll.gameObject.GetComponent<PlayerPower>().setPowerCount();
            Destroy(gameObject,2f);
            
        }
    }

    
}
