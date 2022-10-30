using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float _rotationSpeed = 20;
    [SerializeField]
    private GameObject _explosion;
    private Player _player;
    private SpawnManager _spawnManager;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * _rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Laser"))
        {
            GameObject explosionAnimation = Instantiate(_explosion, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(explosionAnimation, 3f);
            Destroy(this.gameObject);
        }
        if (collision.CompareTag("Player"))
        {
            _player.Damage();
            GameObject explosionAnimation = Instantiate(_explosion, transform.position, Quaternion.identity);
            Destroy(explosionAnimation, 3f);
            Destroy(this.gameObject);
        }
        _spawnManager.StartSpawning();
    }
}