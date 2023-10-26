using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;
using UnityEngine.EventSystems;

public class Shotgun : Weapon
{
    public float rateOfFire = 1f;
    public float distance = 10f;
    public float pushForce = 10f;
    public float startAngle = -30f;
    public float endAngle = 30f;
    public float step;
    public int damage=10;
    public GunAnimatorController animatorController;
    public ParticleHitSystemController particles;

    float currentRateOfFire = 0f;
    
    public override void InputClicked()
    {
        ShootGun();
    }

    public override void InputHold()
    {
        //Don't do anything;
    }

    public override void ShootGun()
    {
       
        if (weaponAmmo.CurrentAmmo > 0 && currentRateOfFire < 0)
        {
            gunAudioController.ShootGun(0f);
            ((ShotgunAudioController)gunAudioController).ShotGunReloadSound(0.6f);
            animatorController.Shoot();
            weaponAmmo.ReduceAmmo(1);
            currentRateOfFire = rateOfFire;

            float currentAngle = startAngle;
            List<RaycastHit> hits = new List<RaycastHit>();
            for (float i = currentAngle; i < endAngle; i += step)
            {
                Ray ray = new Ray(transform.position, Quaternion.Euler(new Vector3(0, i, 0)) * transform.forward);
                RaycastHit[] hit= Physics.RaycastAll(ray, distance, layerMask);
                hits.AddRange(hit);
                
            }

            for(int i = 0; i < hits.Count; i++)
            {
                if(hits[i].collider.attachedRigidbody)
                    hits[i].collider.attachedRigidbody.AddExplosionForce(pushForce, hits[i].point, 1);

                EnemyGetDamage enemyDamage = hits[i].collider.GetComponent<EnemyGetDamage>();
                if(enemyDamage != null)
                {
                    enemyDamage.EnemyTakeDamage(damage);
                    particles.PlayAtPosition(hits[i].point);
                }
            }

        }else if(weaponAmmo.CurrentAmmo <= 0)
        {
            if(!gunAudioController.IsPlaying())
                gunAudioController.OutOfAmmo(0f);
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        //temp
        weaponAmmo.ResetAmmo();
        
    }

    // Update is called once per frame
    void Update()
    {
        currentRateOfFire -= Time.deltaTime;
    }

    public override void WalkingSet(bool walking)
    {
        animatorController.SetWalking(walking);
    }

}
