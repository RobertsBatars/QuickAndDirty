using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentPlacer : MonoBehaviour
{
    [SerializeField] private GameObject humanPrefab;
    [SerializeField] private int humanCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SpawnHumans(Vector2 resolution, List<List<Tile>> tiles)
    {
        for (int i = 0; i < humanCount; i++)
        {
            while (true)
            {
                Vector3 pointFrom = new Vector3(Random.Range(0, resolution.x*10), 10, Random.Range(0, resolution.y*10));
                RaycastHit ground;
                if (Physics.Raycast(pointFrom, Vector3.down, out ground, 20))
                {
                    if (ground.collider.CompareTag("Ground"))
                    {
                        GameObject human = Instantiate(humanPrefab, ground.point, Quaternion.identity);
                        human.transform.position += new Vector3(0, human.transform.localScale.y / 2, 0);
                        break;
                    }
                }
            }
        }
    }
}
