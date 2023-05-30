using System;
using UnityEngine;

public class WeaponToggle : MonoBehaviour
{
    [SerializeField] private GameObject[] _weapons;
    private int _currentWeapon;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
            ChangeWeapon();
    }

    public void ChangeWeapon()
    {
        _weapons[_currentWeapon].SetActive(false);
        _currentWeapon = _currentWeapon == 0 ? 1 : 0;
        _weapons[_currentWeapon].SetActive(true);
    }
}