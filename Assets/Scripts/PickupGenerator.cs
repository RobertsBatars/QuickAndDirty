using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupGenerator : MonoBehaviour
{
    [SerializeField] private GameObject boxPrefab;
    [SerializeField] private GameObject dropoffPrefab;
    [SerializeField] private GameObject bombPickupPrefab;
    [Space]
    [SerializeField] private int bombCount;
    
    public void GenerateNewPackage(Vector2 resolution)
    {
        SpawnPrefab(boxPrefab, resolution, 0.5f);
    }

    public void GenerateBombs(Vector2 resolution)
    {
        for (int i = 0; i < bombCount; i++)
        {
            SpawnPrefab(bombPickupPrefab, resolution, 0);
        }
    }

    private void SpawnPrefab(GameObject prefab, Vector2 resolution, float height)
    {
        while (true)
        {
            Vector3 pointFrom = new Vector3(Random.Range(0, resolution.x * 10), 10, Random.Range(0, resolution.y * 10));
            RaycastHit ground;
            if (Physics.Raycast(pointFrom, Vector3.down, out ground, 20))
            {
                if (ground.collider.CompareTag("Road"))
                {
                    GameObject obj = Instantiate(prefab, ground.point, Quaternion.identity);
                    obj.transform.position += new Vector3(0, height, 0);
                    break;
                }
            }
        }
    }

    public void GenerateNewDropoff(Vector2 resolution)
    {
        SpawnPrefab(dropoffPrefab, resolution, 0);
    }
}
