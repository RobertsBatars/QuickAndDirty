using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityGenerator : MonoBehaviour
{
    public Vector2 resolution;
    private List<List<Tile>> tiles;

    // Start is called before the first frame update
    void Start()
    {
        InitTiles();
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
    void PlaceRoadTile()
    {

    }
}
