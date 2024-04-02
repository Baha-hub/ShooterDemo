using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform playerTransform, cameraTransform;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnFrequency;
    private Transform[] _transforms = new Transform[4];

    private void Start()
    {
        _transforms[0] = transform.GetChild(0);
        _transforms[1] = transform.GetChild(1);
        _transforms[2] = transform.GetChild(2);
        _transforms[3] = transform.GetChild(3);

        for (int i = 0; i < _transforms.Length; i++)
        {
            GameObject enemyGO = Instantiate(enemyPrefab, _transforms[i].position, quaternion.identity);
            Enemy enemy = enemyGO.GetComponent<Enemy>();
            enemy.player = playerTransform;
            enemy.SetCameraTransform(cameraTransform);
        }

        StartCoroutine(RecursiveSpawn());
    }

    IEnumerator RecursiveSpawn()
    {
        yield return new WaitForSeconds(spawnFrequency);
        for (int i = 0; i < _transforms.Length; i++)
        {
            GameObject enemyGO = Instantiate(enemyPrefab, _transforms[i].position, quaternion.identity);
            Enemy enemy = enemyGO.GetComponent<Enemy>();
            enemy.player = playerTransform;
            enemy.SetCameraTransform(cameraTransform);
        }

        StartCoroutine(RecursiveSpawn());
    }
}