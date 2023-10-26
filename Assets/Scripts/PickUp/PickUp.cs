using Character;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public bool isAmmo;
    public bool isArmor;
    public bool isHealth;

    public Ammo ammo;
    public PickupSoundController soundController;

    private HealthPickUp _healthPickUp;

    public int amount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            if (isAmmo)
            {
                if (ammo.CurrentAmmo < ammo.MaxAmmo)
                {
                    Instantiate(soundController, transform.position, Quaternion.identity);
                    ammo.AddAmmo(amount);
                    Destroy(gameObject);
                }
            }
            PlayerHealth ph = other.gameObject.GetComponent<PlayerHealth>();
            if (isArmor)
            {
                if (!ph.IsFullArmor)
                {
                    Instantiate(soundController, transform.position, Quaternion.identity);
                    ph.GiveArmor(amount, this.gameObject);
                }
            }

            if (isHealth)
            {
                if (!ph.IsFullHealth)
                {
                    Instantiate(soundController, transform.position, Quaternion.identity);
                    other.gameObject.GetComponent<PlayerHealth>().GiveHealth(amount, this.gameObject);
                }
            }
        }
    }
}
