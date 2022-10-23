using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private float _spawnRate = 5;
    [SerializeField]
    private GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnRoutine");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-8f, 8f), 7f, 0);
            Instantiate(enemy, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(_spawnRate);
        }
    }
}