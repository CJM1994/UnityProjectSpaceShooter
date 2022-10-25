using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private string _powerupName;

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
            if (player == null) Debug.Log("Player is null");

            switch (_powerupName)
            {
                case "TripleLaserPowerup":
                    player.ActivateTripleShotPowerup();
                    break;

                case "SpeedPowerup":
                    player.ActivateSpeedPowerup();
                    break;

                case "ShieldPowerup":
                    // Todo: Add public void for shield powerup
                    break;

                default:
                    Debug.Log("_powerupName not found");
                    break;
            }

            Destroy(this.gameObject);
        }
    }
}
