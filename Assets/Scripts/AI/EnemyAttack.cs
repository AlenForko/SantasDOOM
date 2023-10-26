using System;
using AI;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
    {
        public float enemyAttackTime;

        public GameObject projectile;

        private Transform _player;

        public NavMeshAgent agent;
        
        public bool _alreadyAttacked;

        public EnemyAwareness enemyAwareness;
        
        public LayerMask playerMask;

        private void Start()
        {
            _player = FindObjectOfType<CharacterMovement>().transform;
        }

        private void Update()
        {
            if (enemyAwareness.isAggro)
            {
                EnemyAttacking();
            }
        }

        private void EnemyAttacking()
        {
            transform.LookAt(_player);

            if (!_alreadyAttacked)
            {
                Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
                rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
                rb.AddForce(transform.up * 4f, ForceMode.Impulse);

                _alreadyAttacked = true;
                Invoke(nameof(ResetAttack), enemyAttackTime);
            }
        }
        
        private bool ResetAttack()
        {
            return _alreadyAttacked = false;
        }
    }