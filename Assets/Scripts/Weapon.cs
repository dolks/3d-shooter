using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 50;
    [SerializeField] ParticleSystem muzzleFlash;

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }
    }

    private void Shoot() {
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range)) {
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target) {target.TakeDamage(damage);}
        }
    }
}
