using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Ammo")]
public class Ammo : ScriptableObject
{
    public int MaxAmmo
    {
        get
        {
            return _maxAmmo;
        }
    }
    
    public int CurrentAmmo
    {
        get
        {
            return _currentAmmo;
        }
    }

    [SerializeField] int _maxAmmo;
    int _currentAmmo;

    public void ReduceAmmo(int ammo)
    {
        _currentAmmo -= ammo;
        _currentAmmo = Mathf.Clamp(_currentAmmo, 0, _maxAmmo);
        CanvasManager.Instance.UpdateAmmo(_currentAmmo);
    }

    public void AddAmmo(int ammo)
    {
        _currentAmmo += ammo;
        _currentAmmo = Mathf.Clamp(_currentAmmo, 0, _maxAmmo);
        CanvasManager.Instance.UpdateAmmo(_currentAmmo);
    }

    public void ResetAmmo()
    {
        _currentAmmo = _maxAmmo;
        CanvasManager.Instance.UpdateAmmo(_currentAmmo);
    }
}
