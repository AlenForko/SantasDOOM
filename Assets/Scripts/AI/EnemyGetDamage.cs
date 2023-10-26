using System;
using Sound;
using UnityEngine;

namespace AI
{
    public class EnemyGetDamage : MonoBehaviour
    {
        
        private EnemyHealth _health;
        private EnemyArmor _armor;

        private int _remainingDamage;

        public bool isDead;
        public HitSoundController hitSoundController;

        private void Start()
        {
            _health = GetComponent<EnemyHealth>();
            _armor = GetComponent<EnemyArmor>();
        }

        public void EnemyTakeDamage(int damage)
        {
            
            if (_armor._currentArmor > 0)
            {
                if (_armor._currentArmor >= damage)
                {
                    _armor._currentArmor -= damage;
                }
                else if (_armor._currentArmor < damage)
                {
                    _remainingDamage = _armor._currentArmor - damage;
                    _armor._currentArmor = 0;
                    _health._currentHealth -= _remainingDamage;
                }
            }
            else
            {
                _health._currentHealth -= damage;
            }
            hitSoundController.HitSoundPlay();
            if (_health._currentHealth <= 0)
            {
                isDead = true;
                Destroy(gameObject);
            }
        }
    }
}
