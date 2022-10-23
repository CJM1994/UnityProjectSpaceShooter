﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;
    private float horizontalBounds = 11.3f;
    [SerializeField]
    private float verticalBoundsUp = -2;
    [SerializeField]
    private float verticalBoundsDown = -4.5f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, -4, 0);
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
    }

    void CalculateMovement()
    {
        // Input
        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * _speed * Time.deltaTime);

        // Bounds
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, verticalBoundsDown, verticalBoundsUp), 0);
        if (transform.position.x > horizontalBounds || transform.position.x < -horizontalBounds)
        {
            transform.position = new Vector3(-transform.position.x, transform.position.y, transform.position.z);
        }
    }
}
