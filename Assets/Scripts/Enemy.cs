using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;

    // Update is called once per frame
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
            Player player = collision.transform.GetComponent<Player>();
            if (player == null) Debug.Log("Player is null");
            collision.transform.GetComponent<Player>().Damage();

            Destroy(this.gameObject);
        }
        if (collision.tag == "Laser")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
