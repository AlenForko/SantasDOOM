using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

public class WeaponControlSystem : MonoBehaviour
{
    public Weapon[] weapons;
    public int startWeapon = 0;

    public Weapon CurrentWeapon
    {
        get
        {
            return currentWeapon;
        }
    }

    Weapon currentWeapon;
    int currentWeaponIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentWeapon = weapons[currentWeaponIndex];
        RefreshWeapons();
    }

    public void WeaponClicked(int keyBoard)
    {
        int weaponIndex = keyBoard - 1;
        if (weaponIndex < weapons.Length && weaponIndex >= 0)
        {
            
            currentWeaponIndex = weaponIndex;
            currentWeapon = weapons[weaponIndex];
            RefreshWeapons();
        }
    }

    public void WeaponScrolled(float scrollDelta)
    {
        currentWeaponIndex+= (int)Mathf.Sign(scrollDelta);
        if (currentWeaponIndex >= weapons.Length)
        {
            currentWeaponIndex = 0;
        }
        if(currentWeaponIndex < 0)
        {
            currentWeaponIndex = weapons.Length-1;
        }

        currentWeapon = weapons[currentWeaponIndex];
        RefreshWeapons();
    }

    void RefreshWeapons()
    {
        for(int i = 0; i < weapons.Length; i++)
        {
            if (i == currentWeaponIndex)
            {
                weapons[i].gameObject.SetActive(true);
                CanvasManager.Instance.UpdateAmmo(weapons[i].weaponAmmo.CurrentAmmo);
                CanvasManager.Instance.CurrentWeaponChanged(currentWeaponIndex);
            }
            else
            {
                weapons[i].gameObject.SetActive(false);
            }
        }
    }

    public void WeaponShotStart()
    {
        currentWeapon.InputClicked();
    }

    public void WeaponShotEnd()
    {
        currentWeapon.InputReleased();
    }

    public void WeaponShotHold()
    {
        currentWeapon.InputHold();
    }
}
