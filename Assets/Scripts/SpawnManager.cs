using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private float _spawnRate = 5;
    [SerializeField]
    private GameObject _enemy;
    [SerializeField]
    private GameObject _enemyContainer;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-8f, 8f), 7f, 0);
            Instantiate(_enemy, spawnPosition, Quaternion.identity, _enemyContainer.transform);
            yield return new WaitForSeconds(_spawnRate);
        }
    }
}