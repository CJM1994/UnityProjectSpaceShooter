using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Movement
    [SerializeField]
    private float _speed = 3.5f;

    [SerializeField]
    private float _verticalBoundsUp = -2.0f;
    [SerializeField]
    private float _verticalBoundsDown = -4.5f;
    private float horizontalBounds = 11.3f;

    [SerializeField]
    private float _fireRate = 0.5f;
    private float nextFireTime;

    [SerializeField]
    private int _lives = 3;
    private SpawnManager _spawnManager;

    // Firing
    [SerializeField]
    private GameObject _laserPrefab;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, -4, 0);
        _spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFireTime)
        {
            FireLaser();
        }
    }

    void CalculateMovement()
    {
        // Input
        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * _speed * Time.deltaTime);

        // Bounds
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, _verticalBoundsDown, _verticalBoundsUp), 0);
        if (transform.position.x > horizontalBounds || transform.position.x < -horizontalBounds)
        {
            transform.position = new Vector3(-transform.position.x, transform.position.y, transform.position.z);
        }
    }

    void FireLaser()
    {

        nextFireTime = Time.time + _fireRate;
        Vector3 laserStartPosition = new Vector3(transform.position.x, transform.position.y + 1.2f, transform.position.z);
        Instantiate(_laserPrefab, laserStartPosition, Quaternion.identity);
    }

    public void Damage()
    {
        _lives -= 1;

        if (_lives < 1)
        {
            if (_spawnManager != null)
            {
                _spawnManager.OnPlayerDeath();
            }
            else Debug.Log("Spawn Manager is null");

            Destroy(this.gameObject);
        }
    }
}
