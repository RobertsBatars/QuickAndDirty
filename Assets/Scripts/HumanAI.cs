using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanAI : MonoBehaviour
{
    public float speed = 10;

    private Rigidbody rb;
    private CityGenerator cityGenerator;
    private Vector2 resolution;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        cityGenerator = FindObjectOfType<CityGenerator>();
        resolution = cityGenerator.resolution;
    }

    private void Update()
    {
        RaycastHit wall;
        if (Physics.Raycast(transform.position, transform.forward, out wall, 5)){
            RotateRandomly(90);
        }
    }

    private void FixedUpdate()
    {
        if (transform.position.x >= (resolution.x - 1) * 10 || transform.position.x < 10 || transform.position.z < 10 || transform.position.z >= (resolution.y - 1) * 10)
        {
            RotateRandomly(180);
        }
        rb.MovePosition(transform.position + transform.forward * speed * Time.fixedDeltaTime);
    }

    private void RotateRandomly(float angle)
    {
        if (Random.Range(0, 2) == 1)
        {
            transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y + angle, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y - angle, 0);
        }
    }
}
