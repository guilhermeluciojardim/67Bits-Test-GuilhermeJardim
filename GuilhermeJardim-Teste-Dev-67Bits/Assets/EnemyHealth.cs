using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Check for Player Punch
    void OnCollisionEnter(Collision coll){
        if ((coll.gameObject.tag == "Player") && (coll.gameObject.GetComponent<SphereCollider>())){
            Debug.Log("Soco");
        }
    }
}
