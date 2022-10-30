using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;
    private Player _player;
    private BoxCollider2D _boxCollider2D;
    [SerializeField]
    private GameObject _explosion;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -7f)
        {
            transform.position = new Vector3(Random.Range(-8f, 8f), 7, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (_player != null) _player.Damage();
            handleEnemyDeath();
        }
        if (collision.CompareTag("Laser"))
        {
            if (_player != null) _player.AddScore(10);
            Destroy(collision.gameObject);
            handleEnemyDeath();
        }
    }

    void handleEnemyDeath()
    {
        GameObject explosionAnimation = Instantiate(_explosion, transform.position, Quaternion.identity);
        Destroy(explosionAnimation, 2.8f);
        Destroy(this.gameObject);
    }
}
