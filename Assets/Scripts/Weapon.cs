using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 50;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitVFX;

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
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target) {target.TakeDamage(damage);}
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject newHitVFX = Instantiate(hitVFX, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(newHitVFX, 0.1f);
    }
}
