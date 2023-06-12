using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityGenerator : MonoBehaviour
{
    public Vector2 resolution;
    [SerializeField] GameObject startingTile;

    private List<List<Tile>> tiles;
    private RoadTileChooser chooser;

    // Start is called before the first frame update
    void Start()
    {
        InitTiles();
        chooser = GetComponent<RoadTileChooser>();
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
        if (x >= resolution.x || x < 0 || y < 0 || y >= resolution.y)
        {
            return;
        }
        Tile tile = chooser.ChooseAcceptableRoadTile(tiles[y][x]);
        Instantiate(tile.tile, new Vector3(x * 10, y * 10, 0), Quaternion.Euler(0, tile.rotation, 0));
        
        if (tile.top == 1)
        {
            PlaceRoadTile(x, y + 1);
        }
    }
}
