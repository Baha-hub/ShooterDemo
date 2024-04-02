using System;
using StarterAssets;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private StarterAssetsInputs _input;
    [SerializeField] private Transform BulletSpawnPoint;
    [SerializeField] private float autoShootCooldown;
    private float timeCounter = 0;
    private bool cooldown = true;
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    private BulletSpawner _bulletSpawner;
    private Vector3 aimDir;
    [SerializeField] private ParticleSystem _particleSystem;

    private void Awake()
    {
        _input = GetComponent<StarterAssetsInputs>();
        _bulletSpawner = BulletSpawner.Instance;
        
    }
    private void Start()
    {
        for (int i = 0; i <= 5; i++) // t
        {
            Shoot(Quaternion.identity);
        }
    }

    private void Update()
    {
        if (_input.shoot && _input.aim)
        {
            Ray ray = TargetPosition.Instance.ray;
            Vector3 mouseWorldPosition;
            if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
            {
                mouseWorldPosition = raycastHit.point;
            }
            else
            {
                mouseWorldPosition = ray.GetPoint(100f);
            }

            Vector3 aimDir = (mouseWorldPosition - BulletSpawnPoint.position).normalized;
            Quaternion aimRotation = Quaternion.LookRotation(aimDir, Vector3.up);
            
            timeCounter -= Time.deltaTime;
            if (timeCounter <= 0)
            {
                Shoot(aimRotation);
                _particleSystem.Play();
                AudioManager.Instance.PlaySFX("Shoot");
                AudioManager.Instance.PlaySFX("ShellsToGround");
                timeCounter = autoShootCooldown;
            }
        }
        else
        {
            timeCounter = 0;
        }
        
    }

    private void Shoot(Quaternion aimRotation)
    {
        _bulletSpawner.InstantiateBullets(aimRotation);
    }
}