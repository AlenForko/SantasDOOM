using System;
using UnityEngine;
using UnityEngine.AI;

namespace AI
{
    public class EnemyAI : MonoBehaviour
    {
        public float dist;
        public float calculationRate = 3f;
        public float distanceFromPlayer = 5f;
        public Vector3 dir;
        private EnemyAwareness _enemyAwareness;
        private Transform _playerTransform;
        private NavMeshAgent _enemyNavMeshAgent;
        private float currentCalculationRate = 0;
        private void Start()
        {
            _enemyAwareness = GetComponent<EnemyAwareness>();
            _enemyNavMeshAgent = GetComponent<NavMeshAgent>();
            _playerTransform = FindObjectOfType<CharacterMovement>().transform.parent;
        }

        private void FixedUpdate()
        {
            if (_enemyAwareness.isAggro && currentCalculationRate <= 0 && Vector3.Distance(_playerTransform.position, transform.position) > distanceFromPlayer)
            {
                currentCalculationRate = calculationRate;
                Vector3 playerPos = _playerTransform.position;
                playerPos.y = 0f;
                Vector3 enemyPos = transform.position;
                enemyPos.y = 0f;

                dir = playerPos - enemyPos;

                _enemyNavMeshAgent.SetDestination(transform.position + dir.normalized * dist);
            }
            else
            {
                currentCalculationRate -= Time.deltaTime;
            }
        }
    }
}
