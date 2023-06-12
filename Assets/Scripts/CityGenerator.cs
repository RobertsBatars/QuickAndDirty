using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityGenerator : MonoBehaviour
{
    public Vector2 resolution;
    [SerializeField] GameObject startingTile;
    private List<List<Tile>> tiles;

    // Start is called before the first frame update
    void Start()
    {
        InitTiles();
        PlaceRoadTile((int)resolution.x / 2, (int)resolution.y/2);
    }

    void InitTiles()
    {
        for (int i = 0; i < resolution.y; i++)
        {
            tiles.Add(new List<Tile>());
            for (int j = 0; j < resolution.x; j++)
            {
                tiles[i].Add(new Tile());
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateCity()
    {

    }
    void PlaceRoadTile(int x, int y)
    {

    }
}
