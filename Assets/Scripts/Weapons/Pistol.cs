using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using AI;

public class Pistol : Weapon
{
    public float pistolDistance = 100;
    public float fireRate = 0.1f;
    public int damage=5;
    public GunAnimatorController gunAnimatorController;
    public ParticleHitSystemController particles;
    float currentFireRate;

    private void Start()
    {
        currentFireRate = 0;
        weaponAmmo.ResetAmmo();
    }

    private void Update()
    {
        if(currentFireRate > 0)
        {
            currentFireRate -= Time.deltaTime;
        }
    }

    public override void ShootGun()
    {
        if (currentFireRate <= 0 && weaponAmmo.CurrentAmmo > 0)
        {
            gunAudioController.ShootGun(0f);
            gunAnimatorController.Shoot();
            weaponAmmo.ReduceAmmo(1);
            currentFireRate = fireRate;
            onGunShot.Invoke();
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit, pistolDistance, layerMask))
            {
                EnemyGetDamage enemyDamage = raycastHit.collider.GetComponent<EnemyGetDamage>();
                if (enemyDamage != null)
                {
                    particles.PlayAtPosition(raycastHit.point);
                    enemyDamage.EnemyTakeDamage(damage);
                }
            }
        }
        else if (weaponAmmo.CurrentAmmo <= 0)
        {
            if (!gunAudioController.IsPlaying())
            {
                gunAudioController.OutOfAmmo(0f);
            }
        }
    }

    public override void WalkingSet(bool walking)
    {
        gunAnimatorController.SetWalking(walking);
    }
}
