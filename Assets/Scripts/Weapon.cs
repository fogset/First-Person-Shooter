using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    Camera FPCamera;

    [SerializeField]
    float range = 100f;

    [SerializeField]
    float damage = 30f;

    [SerializeField]
    ParticleSystem muzzleFlash;

    [SerializeField]
    GameObject hitEffect;

    [SerializeField]
    Ammo ammoSlot;

    [SerializeField]
    AmmoType ammoType;

    [SerializeField]
    float timeBetweenShots = 0.5f;

    bool canShoot = true;

    [SerializeField]
    bool countineFire = false;

    private void OnEnable()
    {
        canShoot = true;
    }

    void Update()
    {
        if (
            Input.GetKey(KeyCode.Mouse0) &&
            countineFire == true &&
            canShoot == true
        )
        {
            StartCoroutine(Shoot());
        }
        else if (Input.GetMouseButtonDown(0) && canShoot == true)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        fire();
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    private void fire()
    {
        if (ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            PlayMuzzleFlash();
            ProcessRaycast();
            ammoSlot.ReduceCurrentAmmo (ammoType);
        }
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (
            Physics
                .Raycast(FPCamera.transform.position,
                FPCamera.transform.forward,
                out hit,
                range)
        )
        {
            CreateHitImpact (hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage (damage);
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact =
            Instantiate(hitEffect,
            hit.point,
            Quaternion.LookRotation(hit.normal));
        Destroy(impact, 1f);
    }
}
