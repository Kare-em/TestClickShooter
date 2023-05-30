using System;
using UnityEngine;
using UnityEngine.Serialization;

public class WeaponController : MonoBehaviour
{
    [SerializeField] public float BulletSpeed;
    [SerializeField] public float Damage;
    [SerializeField] private float _shootInterval = 0.3f;
    [SerializeField] private Transform _muzzle;

    private Pool _bullets;
    private GameObject _currentBullet;
    private AudioSource _audioSource;

    private float _currentReloadingTime;
    private float _lastShotTime = 0.0f;


    private void OnEnable()
    {
        _bullets = GetComponent<Pool>();
        _audioSource ??= GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
            Shoot();
    }


    void Shoot()
    {
        if (Time.time - _lastShotTime >= _shootInterval)
        {
            // create bullet
            InitBullets();

            _lastShotTime = Time.time;
        }
    }

    public void InitBullets()
    {
        _currentBullet = _bullets.GetObject();
        _currentBullet.transform.position = _muzzle.position;
        _currentBullet.transform.rotation = _muzzle.rotation;
        _currentBullet.SetActive(true);
        _currentBullet.GetComponent<BulletController>().Release(BulletSpeed, Damage);
    }
}