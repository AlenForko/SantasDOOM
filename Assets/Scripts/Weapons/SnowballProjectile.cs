using System;
using System.Collections;
using System.Collections.Generic;
using Character;
using UnityEngine;

public class SnowballProjectile : MonoBehaviour
{
    private PlayerHealth _playerHealth;

    public int projectileDamage;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(projectileDamage);
        }
        Destroy(gameObject);
    }
}
