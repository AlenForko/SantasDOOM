using System;
using UnityEngine;

namespace AI
{
    public class EnemyArmor : MonoBehaviour
    {
        public int maxArmor = 100;

        public int _currentArmor;

        private void Start()
        {
            _currentArmor = maxArmor;
        }
    }
}
