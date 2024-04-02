using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour, IBullet
{
    private Rigidbody _rigid;
    [SerializeField] private float speed, bulletLifeTime, bulletDamage;
    private ObjectPool<Bullet> _pool;
    [SerializeField] private GameObject vfxBlood;
    [SerializeField] private GameObject vfxRandom;
    private AudioSource _audioSource;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }
    public void OnObjectSpawn()
    {
        _rigid.velocity = Vector3.zero;
        StartCoroutine(BulletLifetime());

        IEnumerator BulletLifetime()
        {
            yield return new WaitForSeconds(bulletLifeTime);
            DestroyBullet();
        }
        _rigid.velocity = transform.forward * speed;   
    }

    private void OnDisable()
    {
        _rigid.velocity = Vector3.zero;
        transform.rotation = Quaternion.identity;
    }

    public void SetPool(ObjectPool<Bullet> pool)
    {
        _pool = pool;
    }

    private void DestroyBullet()
    {
        if (_pool != null)
        {
            _pool.Release(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        DestroyBullet();
        
        if (other.gameObject.GetComponent<Enemy>() != null)
        {
            // Hit target
            Instantiate(vfxBlood, transform.position, Quaternion.identity);
            AudioManager.Instance.PlaySFX("BulletHit");
            other.gameObject.GetComponent<Enemy>().TakeDamage(bulletDamage);
        }
        else
        {
            // Hit something else
            AudioManager.Instance.PlaySFX("BulletHit");
            Instantiate(vfxRandom, transform.position, Quaternion.identity);
        }
    }
    
}