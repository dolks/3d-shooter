using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider) {
        Debug.Log("Entered");
        Destroy(gameObject);
    }
}
