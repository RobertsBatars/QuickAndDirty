using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Package : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventoryLogic player = other.GetComponent<PlayerInventoryLogic>();
            if (!player.hasPackage)
            {
                player.hasPackage = true;
                FindObjectOfType<PickupGenerator>().GenerateNewPackage(FindObjectOfType<CityGenerator>().resolution);
                Destroy(gameObject);
            }
        }
    }
}
