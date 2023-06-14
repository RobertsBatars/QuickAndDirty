using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCar : MonoBehaviour
{
    [SerializeField] private Vector3 spawnOffset;

    private CityGenerator generator;
    // Start is called before the first frame update
    void Start()
    {
        generator = FindObjectOfType<CityGenerator>();
        transform.position = new Vector3(generator.resolution.x * 10 / 2, 0, generator.resolution.y * 10 / 2) + spawnOffset;
    }

    private void Update()
    {
        if (transform.position.y < -5)
        {
            transform.position = new Vector3(generator.resolution.x * 10 / 2, 0, generator.resolution.y * 10 / 2) + spawnOffset;
        }
    }
}
