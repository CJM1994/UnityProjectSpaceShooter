using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleLaserPowerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;

    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -7f)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player player = collision.transform.GetComponent<Player>();
            player.ActivateTripleLaser();
            Destroy(this.gameObject);
        }
    }
}
