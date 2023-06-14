using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPointer : MonoBehaviour
{
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            if (GetComponentInParent<PlayerInventoryLogic>().hasPackage)
            {
                target = FindObjectOfType<Dropoff>().transform;
            }
            else
            {
                target = FindObjectOfType<Package>().transform;
            }
        }
        Vector3 dir = (target.position - transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Euler(0, rotation.eulerAngles.y, 0);
    }
}
