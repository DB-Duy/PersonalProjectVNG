using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlash : MonoBehaviour
{
    [SerializeField]
    private Transform muzzleFlash;
    [SerializeField]
    private float _duration;
    [SerializeField]
    private GameObject _flashLight;

    private float _lastShowTime;
    private void OnEnable()
    {
        Hide();
    }

    private void Update()
    {
        if (!muzzleFlash.gameObject.activeSelf) { return; }
        if (Time.time - _lastShowTime >= _duration)
        {
            Hide();
        }
    }

    public void Show()
    {
        _flashLight.SetActive(true);
        RotateMuzzle();
        muzzleFlash.gameObject.SetActive(true);
        _lastShowTime = Time.time;
    }

    private void RotateMuzzle()
    {
        float angle = Random.Range(0, 360f);
        muzzleFlash.localRotation = Quaternion.Euler(0, 0, angle);
    }

    public void Hide()
    {
        _flashLight.SetActive(false);
        muzzleFlash.gameObject.SetActive(false);
    }
}
