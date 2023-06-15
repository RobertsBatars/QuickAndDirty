using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float explosionForce;
    [SerializeField] private GameObject explosion;
    private bool activated = false;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            activated = true;
            GetComponentInChildren<Light>().color = Color.green;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Entity") && activated)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            other.attachedRigidbody.AddExplosionForce(explosionForce, transform.position, GetComponent<SphereCollider>().radius*2);
            Destroy(gameObject);
        }
    }
}
