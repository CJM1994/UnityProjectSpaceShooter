using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = -4;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up * _speed * Time.deltaTime);

        if(transform.position.y < -7.0f)
        {
            transform.position = new Vector3(Random.Range(-8f, 8f), 7, 0);
        }
    }
}
