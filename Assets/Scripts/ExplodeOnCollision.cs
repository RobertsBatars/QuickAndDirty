using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeOnCollision : MonoBehaviour
{
    [SerializeField] GameObject explodedPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Instantiate(explodedPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
