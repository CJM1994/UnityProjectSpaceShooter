using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private float _speedPowerupModifier = 2.0f;

    [SerializeField]
    private float _verticalBoundsUp = -2.0f;
    [SerializeField]
    private float _verticalBoundsDown = -4.5f;
    private readonly float _horizontalBounds = 11.3f;

    [SerializeField]
    private float _fireRate = 0.5f;
    private float nextFireTime;

    [SerializeField]
    private int _score = 0;
    private UIManager _uiManager;
    [SerializeField]
    private int _lives = 3;
    private SpawnManager _spawnManager;
    private GameManager _gameManager;

    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _tripleLaserPrefab;
    private AudioSource _laserSound;
    [SerializeField]
    private GameObject _shieldVisualizer;
    [SerializeField]
    private GameObject[] _engines;

    private bool _isTripleLaserActive = false;
    //private bool _isSpeedActive = false;
    private bool _isShieldActive = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, -4, 0);

        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        _spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _laserSound = GetComponent<AudioSource>();
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
        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * _speed * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, _verticalBoundsDown, _verticalBoundsUp), 0);
        if (transform.position.x > _horizontalBounds || transform.position.x < -_horizontalBounds)
        {
            transform.position = new Vector3(-transform.position.x, transform.position.y, transform.position.z);
        }
    }

    void FireLaser()
    {
        nextFireTime = Time.time + _fireRate;

        if (_isTripleLaserActive)
        {
            Vector3 laserStartPosition = new Vector3(transform.position.x - 0.45f, transform.position.y, transform.position.z);
            Instantiate(_tripleLaserPrefab, laserStartPosition, Quaternion.identity);
        }
        else
        {
            Vector3 laserStartPosition = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);
            Instantiate(_laserPrefab, laserStartPosition, Quaternion.identity);
        }

        _laserSound.Play();
    }

    public void ActivateTripleLaser()
    {
        _isTripleLaserActive = true;
        StartCoroutine(DeactivateTripleLaser());
    }

    IEnumerator DeactivateTripleLaser()
    {
        yield return new WaitForSeconds(5);
        _isTripleLaserActive = false;
    }

    public void ActivateSpeed()
    {
        //_isSpeedActive = true;
        _speed *= _speedPowerupModifier;
        StartCoroutine(DeactivateSpeed());
    }

    IEnumerator DeactivateSpeed()
    {
        yield return new WaitForSeconds(5);
        //_isSpeedActive = false;
        _speed /= _speedPowerupModifier;
    }

    public void ActivateShield()
    {
        _isShieldActive = true;
        _shieldVisualizer.SetActive(true);
    }

    public void Damage()
    {
        if (_isShieldActive)
        {
            _isShieldActive = false;
            _shieldVisualizer.SetActive(false);
            return;
        }

        _lives -= 1;
        _uiManager.UpdateLives(_lives);
        addEngineDamage();

        if (_lives < 1)
        {
            _spawnManager.OnPlayerDeath();
            _gameManager.GameOver();
            Destroy(this.gameObject);
        }
    }

    void addEngineDamage()
    {
        if (_engines[0].activeSelf == true)
        {
            _engines[1].SetActive(true);
            return;
        }
        if (_engines[1].activeSelf == true)
        {
            _engines[0].SetActive(true);
            return;
        }

        int whichEngine = Random.Range(0, 2);
        _engines[whichEngine].SetActive(true);
    }

    public void AddScore(int points)
    {
        _score += points;
        _uiManager.UpdateScore(_score);
    }
}
