using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGenerator : MonoBehaviour
{
    [SerializeField] private GameObject emptyTile;
    private List<List<Tile>> tiles;
    
    public void AddBuildingTiles(List<List<Tile>> _tiles, int x, int y, Vector2 resolution)
    {
        tiles = _tiles;
        Tile buildingTile = new Tile(-1, -1, -1, -1, 360, emptyTile);
        if (y < resolution.y - 1 && tiles[y + 1][x].tile == null && CheckEmpty(x, y + 1))
        {
            if (Random.Range(0, 1) == 1)
            {
                tiles[y + 1][x] = buildingTile;
            }
        }
        if (y > 0 && tiles[y - 1][x].tile == null && CheckEmpty(x, y - 1))
        {
            if (Random.Range(0, 1) == 1)
            {
                tiles[y - 1][x] = buildingTile;
            }
        }
        if (x > 0 && tiles[y][x - 1].tile == null && CheckEmpty(x - 1, y))
        {
            if (Random.Range(0, 1) == 1)
            {
                tiles[y][x - 1] = buildingTile;
            }
        }
        if (x < resolution.x - 1 && tiles[y][x + 1].tile == null && CheckEmpty(x + 1, y))
        {
            if (Random.Range(0, 1) == 1)
            {
                tiles[y][x + 1] = buildingTile;
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
                if (tiles[j][i].tile == null || tiles[j][i].rotation == 360)
                {
                    Instantiate(emptyTile, new Vector3(j * 10, 0, i * 10), Quaternion.identity);
                }
            }
        }
    }
}
