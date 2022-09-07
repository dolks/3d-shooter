using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health = 100 ;
    bool isDead = false;

    public bool GetIsDead() {
        return isDead;
    }
    
    public void TakeDamage(float damage) {
        if (isDead) { return; }
        BroadcastMessage("OnDamageTaken");
        health -= damage;
        if (health <= 0) {
            isDead = true;
            GetComponent<Animator>().SetTrigger("die");
        }
    }
}
