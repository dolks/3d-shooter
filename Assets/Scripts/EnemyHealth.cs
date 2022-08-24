using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health = 100 ;
    
    public void TakeDamage(float damage) {
        BroadcastMessage("OnDamageTaken");
        health -= damage;
        if (health <= 0) {
            Destroy(gameObject);
        }
    }
}
