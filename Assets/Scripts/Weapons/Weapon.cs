using UnityEngine;
using UnityEngine.Events;

public abstract class Weapon : MonoBehaviour
{
    public Ammo weaponAmmo;
    public LayerMask layerMask;
    public GunAudioController gunAudioController;
    public UnityEvent onGunShot;

    public virtual void InputClicked()
    {
        
    }
    public virtual void InputHold()
    {
        ShootGun();
    }
    public virtual void InputReleased()
    {

    }

    public abstract void ShootGun();

    public virtual void WalkingSet (bool walking) { }
}
