using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;
    private Player _player;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
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
        if (collision.tag == "Player")
        {
            if (_player != null) _player.Damage();
            Destroy(this.gameObject);
        }
        if (collision.tag == "Laser")
        {
            if (_player != null) _player.AddScore(10);
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
