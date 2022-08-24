using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health = 100;

    void Start()
    {
        
    }

    public void ProcessHit(float damage) {
        if (health < 0) {return;}
        health -= damage;
        if (health <= 0) {
            health = 100f;
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
}
