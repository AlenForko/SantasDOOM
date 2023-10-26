using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Character
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private int _maxHealth = 100;
        [SerializeField] private int _currentHealth;

        private int _maxArmor = 100;
        private int _currentArmor;
        public HitSoundController hitSoundController;

        public bool IsFullHealth => _maxHealth <= _currentHealth;

        public bool IsFullArmor => _maxArmor <= _currentArmor;


        private void Start()
        {
            _currentHealth = _maxHealth;

            CanvasManager.Instance.UpdateHealth(_currentHealth);
            CanvasManager.Instance.UpdateArmor(_currentArmor);
        }

        public void TakeDamage(int dmg)
        {
            if (_currentArmor > 0)
            {   
                //Checks if armor value is higher than damage value.
                if (_currentArmor >= dmg)
                {
                    _currentArmor -= dmg;
                }
                //If current armor is smaller than damage, take damage to armor and distribute remainder to health.
                else if (_currentArmor < dmg)
                {
                    int remainingDamage = _currentArmor - dmg;
                    _currentArmor = 0;
                    _currentHealth += remainingDamage;
                }
            }
            else
            {
                _currentHealth -= dmg;
            }
            hitSoundController.HitSoundPlay();
            PlayerDeath();
            
            CanvasManager.Instance.UpdateHealth(_currentHealth);
            CanvasManager.Instance.UpdateArmor(_currentArmor);
        }

        private void PlayerDeath()
        {
            if (_currentHealth <= 0)
            {
                //Reloads current scene once dead. **Change afterwards to restart button.**
                Scene currentScene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(currentScene.buildIndex);
            }
        }

        public void GiveHealth(int amount, GameObject pickUp)
        {
            //Checks if health is less than current health, then picks up the object and destroys it.
            if (_currentHealth < _maxHealth)
            {
                _currentHealth += amount;
                Destroy(pickUp);
            }
            //& if current health is higher than max health, set current health to max and don't destroy object.
            if (_currentHealth >= _maxHealth)
            {
                _currentHealth = _maxHealth;
            }
            CanvasManager.Instance.UpdateHealth(_currentHealth);
        }

        public void GiveArmor(int amount, GameObject pickUp)
        {
            //Checks if armor is less than current armor, then picks up the object and destroys it.
            if (_currentArmor < _maxArmor)
            {
                _currentArmor += amount;
                Destroy(pickUp);
            }
            
            //& if current armor is higher than max armor, set current armor to max and don't destroy object.
            if (_currentArmor > _maxArmor)
            {
                _currentArmor = _maxArmor;
            }
            CanvasManager.Instance.UpdateArmor(_currentArmor);
        }
    }
}
