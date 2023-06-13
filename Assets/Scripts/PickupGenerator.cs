using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupGenerator : MonoBehaviour
{
    [SerializeField] private GameObject boxPrefab;
    [SerializeField] private GameObject dropoffPrefab;
    
    public void GenerateNewPackage(Vector2 resolution)
    {
        while (true)
        {
            Vector3 pointFrom = new Vector3(Random.Range(0, resolution.x * 10), 10, Random.Range(0, resolution.y * 10));
            RaycastHit ground;
            if (Physics.Raycast(pointFrom, Vector3.down, out ground, 20))
            {
                if (ground.collider.CompareTag("Road"))
                {
                    GameObject obj = Instantiate(boxPrefab, ground.point, Quaternion.identity);
                    obj.transform.position += new Vector3(0, obj.transform.localScale.y / 2, 0);
                    break;
                }
            }
        }

        while (true)
        {
            Vector3 pointFrom = new Vector3(Random.Range(0, resolution.x * 10), 10, Random.Range(0, resolution.y * 10));
            RaycastHit ground;
            if (Physics.Raycast(pointFrom, Vector3.down, out ground, 20))
            {
                if (ground.collider.CompareTag("Road"))
                {
                    GameObject obj = Instantiate(dropoffPrefab, ground.point, Quaternion.identity);
                    obj.transform.position += new Vector3(0, obj.transform.localScale.y / 2, 0);
                    break;
                }
            }
        }
    }
}
