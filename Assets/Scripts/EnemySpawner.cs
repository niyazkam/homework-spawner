using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform _enemiesParent;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private int _enemiesCount;
    [SerializeField] private int _secondsToSpawn;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        for (int i = 0; i < _enemiesCount; i++)
        {
            yield return new WaitForSeconds(_secondsToSpawn);
            int index = Random.Range(0, _spawnPoints.Length);
            Vector3 spawnPosition = _spawnPoints[index].position;
            Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity, _enemiesParent);
        }
    }
}
