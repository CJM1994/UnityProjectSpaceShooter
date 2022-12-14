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
    [SerializeField]
    private GameObject[] _powerups;
    [SerializeField]
    private GameObject _powerupContainer;

    public void StartSpawning()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerupRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        yield return new WaitForSeconds(3);

        while (true)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-8f, 8f), 7f, 0);
            Instantiate(_enemy, spawnPosition, Quaternion.identity, _enemyContainer.transform);
            yield return new WaitForSeconds(_spawnRate);
        }
    }

    IEnumerator SpawnPowerupRoutine()
    {
        yield return new WaitForSeconds(3);

        while (true)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-8f, 8f), 7f, 0);
            GameObject randomPowerup = _powerups[Random.Range(0, _powerups.Length)];
            Instantiate(randomPowerup, spawnPosition, Quaternion.identity, _powerupContainer.transform);
            yield return new WaitForSeconds(Random.Range(8, 16));
        }
    }

    public void OnPlayerDeath()
    {
        Destroy(this.gameObject);
    }
}