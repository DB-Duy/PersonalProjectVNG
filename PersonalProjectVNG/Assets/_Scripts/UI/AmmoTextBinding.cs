using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class AmmoTextBinding : MonoBehaviour
{
    [SerializeField]
    [HideInInspector]
    private GunAmmo _gunAmmo;

    [SerializeField]
    private TMP_Text _ammoText;

    private void OnValidate()
    {
        _gunAmmo = GetComponent<GunAmmo>();
    }

    private void Start()
    {
        _gunAmmo.OnAmmoChanged += UpdateAmmo;
        UpdateAmmo();
    }

    private void OnDestroy()
    {

        _gunAmmo.OnAmmoChanged -= UpdateAmmo;
    }

    private void UpdateAmmo()
    {
        _ammoText.text = $"Ammo: {_gunAmmo.LoadedAmmo} / {_gunAmmo.RemainingAmmo}";
    }
}
