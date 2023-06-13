using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGenerator : MonoBehaviour
{
    [SerializeField] private GameObject emptyTile;
    [SerializeField] private GameObject building;
    private List<List<Tile>> tiles;
    private CityGenerator cityGenerator;

    private void Start()
    {
        cityGenerator = GetComponent<CityGenerator>();
    }

    public void AddBuildingTiles(List<List<Tile>> _tiles, int x, int y, Vector2 resolution)
    {
        if (cityGenerator == null)
            cityGenerator = GetComponent<CityGenerator>();

        tiles = _tiles;
        Tile buildingTile = new Tile(-1, -1, -1, -1, 360, emptyTile);
        if (y < resolution.y - 1 && tiles[y + 1][x].tile == null && CheckEmpty(x, y + 1))
        {
            if (Random.Range(0, 10) >= 7)
            {
                tiles[y + 1][x] = buildingTile;
                cityGenerator.SetSurroundingTileValues(x, y+1, buildingTile);
            }
        }
        if (y > 0 && tiles[y - 1][x].tile == null && CheckEmpty(x, y - 1))
        {
            if (Random.Range(0, 10) >= 7)
            {
                tiles[y - 1][x] = buildingTile;
                cityGenerator.SetSurroundingTileValues(x, y - 1, buildingTile);
            }
        }
        if (x > 0 && tiles[y][x - 1].tile == null && CheckEmpty(x - 1, y))
        {
            if (Random.Range(0, 10) >= 7)
            {
                tiles[y][x - 1] = buildingTile;
                cityGenerator.SetSurroundingTileValues(x-1, y, buildingTile);
            }
        }
        if (x < resolution.x - 1 && tiles[y][x + 1].tile == null && CheckEmpty(x + 1, y))
        {
            if (Random.Range(0, 10) >= 7)
            {
                tiles[y][x + 1] = buildingTile;
                cityGenerator.SetSurroundingTileValues(x+1, y, buildingTile);
            }
        }
    }

    private bool CheckEmpty(int x, int y)
    {
        Tile tile = tiles[y][x];
        if (tile.left != 1 && tile.right != 1 && tile.top != 1 && tile.bottom != 1)
        {
            return true;
        }
        return false;
    }

    public void SpawnBuildingTiles()
    {
        for (int i = 0; i < tiles.Count; i++)
        {
            for (int j = 0; j < tiles[i].Count; j++)
            {
                if (tiles[i][j].tile == null || tiles[i][j].rotation == 360)
                {
                    Instantiate(emptyTile, new Vector3(j * 10, 0, i * 10), Quaternion.identity);
                }
            }
        }
    }

    public void SpawnBuildings()
    {
        for (int i = 0; i < tiles.Count; i++)
        {
            for (int j = 0; j < tiles[i].Count; j++)
            {
                if (tiles[i][j].tile == null || tiles[i][j].rotation == 360)
                {
                    GameObject newBuilding = Instantiate(building, new Vector3(j * 10, 0, i * 10), Quaternion.identity);
                    newBuilding.transform.localScale += new Vector3(0, Random.Range(5, 15), 0);
                    newBuilding.transform.position += new Vector3(0, newBuilding.transform.localScale.y/2, 0);
                }
            }
        }
    }
}
