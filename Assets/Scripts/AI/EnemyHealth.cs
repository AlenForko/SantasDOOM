using UnityEngine;

namespace AI
{
    public class EnemyHealth : MonoBehaviour
    {
        public int maxHealth = 100;

        public int _currentHealth;

        private void Start()
        {
            _currentHealth = maxHealth;
        }
    }
}
