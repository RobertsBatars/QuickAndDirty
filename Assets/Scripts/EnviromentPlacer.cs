using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentPlacer : MonoBehaviour
{
    [SerializeField] private GameObject humanPrefab;
    [SerializeField] private int humanCount;
    [Space]
    [SerializeField] private GameObject carPrefab;
    [SerializeField] private int carCount;
    [Space]
    [SerializeField] private PickupGenerator pickupGenerator;

    private Vector2 resolution;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SpawnEnviroment(Vector2 _resolution)
    {
        resolution = _resolution;
        SpawnObjectsOnRoad(humanCount, humanPrefab);
        SpawnObjectsOnRoad(carCount, carPrefab);
        pickupGenerator.GenerateNewPackage(resolution);
    }

    public void SpawnObjectsOnRoad(int count, GameObject prefab)
    {
        for (int i = 0; i < count; i++)
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
                        obj.transform.position += new Vector3(0, obj.transform.localScale.y / 2, 0);
                        break;
                    }
                }
            }
        }
    }

}
