using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    void Start()
    {
        GetComponent<AudioSource>().Play();
        Destroy(gameObject, 3f);
    }
}
