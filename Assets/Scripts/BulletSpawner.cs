using UnityEngine;
using UnityEngine.Pool;

public class BulletSpawner : MonoBehaviour
{
    public ObjectPool<Bullet> _bulletPool;
    [SerializeField] private Bullet bulletPrefab;
    private Bullet currentBullet;
    private Quaternion aimRotation;
    [SerializeField] private Transform bulletSpawnPoint;
    public static BulletSpawner Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        _bulletPool = new ObjectPool<Bullet>(createFunc: InstantiatePoolBullet, actionOnGet: GetBulletFromPool,
            actionOnRelease: ReturnBulletToPool);
    }

    private void ReturnBulletToPool(Bullet obj)
    {
        obj.gameObject.SetActive(false);
    }

    private void GetBulletFromPool(Bullet obj)
    {
        obj.transform.position = bulletSpawnPoint.position;
        obj.transform.rotation = aimRotation;
        obj.SetPool(_bulletPool);
        obj.gameObject.SetActive(true);
    }

    private Bullet InstantiatePoolBullet()
    {
        return Instantiate(bulletPrefab);
    }

    public void InstantiateBullets(Quaternion aimRotation)
    {
        this.aimRotation = aimRotation;
        currentBullet = _bulletPool.Get();
        currentBullet.OnObjectSpawn();
    }
}