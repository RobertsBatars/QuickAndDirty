using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundPickup : MonoBehaviour
{
    [SerializeField] private float rotatingSpeed;

    private void FixedUpdate()
    {
        transform.RotateAround(transform.position, Vector3.up, Time.fixedDeltaTime * rotatingSpeed);
    }
}
