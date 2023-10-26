using System;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class CanvasManager : MonoBehaviour
    {
        public TextMeshProUGUI health;
        public TextMeshProUGUI armor;
        public TextMeshProUGUI ammo;

        public Image healthIndicator;
        public Image weaponIndicator;

        public Sprite healthy;
        public Sprite almostHealthy;
        public Sprite hurt;
        public Sprite dead;
        public Sprite[] weaponSprite;

        public GameObject[] keys;

        private static CanvasManager _instance;

        public static CanvasManager Instance => _instance;

        private void Awake()
        {
            if (_instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
            }
        }

        public void UpdateHealth(int healthValue)
        {
            health.text = healthValue + "%";
            UpdateHealthIndicator(healthValue);
        }
        public void UpdateArmor(int armorValue)
        {
            armor.text = armorValue + "%";
        }
        public void UpdateAmmo(int ammoValue)
        {
            ammo.text = ammoValue.ToString();
        }

        public void UpdateHealthIndicator(int healthValue)
        {
            if (healthValue >= 66)
            {
                healthIndicator.sprite = healthy;
            }

            if (healthValue is < 66 and >= 33)
            {
                healthIndicator.sprite = almostHealthy;
            }

            if (healthValue is < 33 and > 0)
            {
                healthIndicator.sprite = hurt;
            }

            if (healthValue == 0)
            {
                healthIndicator.sprite = dead;
            }
        }

        public void CurrentWeaponChanged(int currentWeapon)
        {
            weaponIndicator.sprite = weaponSprite[currentWeapon];
        }

        public void UpdateKeys(int keyID)
        {
            if (keyID < keys.Length && keyID >= 0)
            {
                keys[keyID].SetActive(true);
            }
        }
    }
}
