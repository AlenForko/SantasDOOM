using System;
using UnityEngine;

namespace AI
{
    public class EnemyAwareness : MonoBehaviour
    {
        public float awarenessRadius = 8f;
        
        public bool isAggro; // Sets the enemy to aggressive mode.

        private Transform _player;

        private EnemyRoam _enemyRoam;

        private void Start()
        {
            _player = FindObjectOfType<CharacterMovement>().transform;
            _enemyRoam = GetComponent<EnemyRoam>();
        }

        private void FixedUpdate()
        {
            // Checks distance from enemy and player
            float dist = Vector3.Distance(transform.position, _player.transform.position);

            if (dist < awarenessRadius)
            {
                isAggro = true;
                _enemyRoam.isRoaming = false;
            }
            else
            {
                isAggro = false;
                _enemyRoam.isRoaming = true;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, awarenessRadius);
        }
    }
}
