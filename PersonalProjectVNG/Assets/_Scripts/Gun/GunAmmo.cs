using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAmmo : MonoBehaviour
{
    private readonly int ReloadTrigger = Animator.StringToHash("Reload");

    [SerializeField]
    [HideInInspector]
    private Animator _animator;

    [SerializeField]
    [HideInInspector]
    private Shooting _shooting;

    [SerializeField]
    private AudioSource[] _reloadSounds;
    [SerializeField]
    private int _magazineSize;
    [SerializeField]
    private int _remainingAmmo;

    private int _loadedAmmo;
    private bool _isReloading;

    public event Action OnAmmoChanged;

    public int LoadedAmmo
    {
        get { return _loadedAmmo; }
        set
        {
            _loadedAmmo = value;
            OnAmmoChanged?.Invoke();
            if (LoadedAmmo <= 0)
            {
                LockShooting();
            }
        }
    }

    public int RemainingAmmo => _remainingAmmo;

    private void OnValidate()
    {
        _animator = GetComponent<Animator>();
        _shooting = GetComponent<Shooting>();
    }

    private void OnEnable()
    {
        _isReloading = false;
        UnlockShooting();
    }

    private void Start()
    {
        LoadedAmmo = _magazineSize;
        _isReloading = false;
        _shooting.OnShoot.AddListener(OnShoot);
    }

    private void Update()
    {
        if (_isReloading) return;

        if (LoadedAmmo <= 0 || Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }


    private void OnDestroy()
    {
        _shooting.OnShoot.RemoveListener(OnShoot);
    }

    private void Reload()
    {
        if (_remainingAmmo <= 0) return;

        LockShooting();
        _isReloading = true;
        _animator.SetTrigger(ReloadTrigger);
    }

    private void OnShoot()
    {
        LoadedAmmo--;
    }

    public void AddAmmo()
    {
        int requiredAmmo = _magazineSize - LoadedAmmo;
        int addedAmmo = Mathf.Min(requiredAmmo, _remainingAmmo);

        _remainingAmmo -= addedAmmo;
        LoadedAmmo += addedAmmo;
    }

    public void PlayReloadPart1Sound() => _reloadSounds[0].Play();

    public void PlayReloadPart2Sound() => _reloadSounds[1].Play();

    public void PlayReloadPart3Sound() => _reloadSounds[2].Play();

    public void PlayReloadPart4Sound() => _reloadSounds[3].Play();

    public void PlayReloadPart5Sound() => _reloadSounds[4].Play();

    public void ReloadToIdle()
    {
        UnlockShooting();
        _isReloading = false;
    }

    private void UnlockShooting()
    {
        if (LoadedAmmo > 0)
        {
            _shooting.Unlock();
        }
    }

    private void LockShooting()
    {
        _shooting.Lock();
    }
}
