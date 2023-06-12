using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadTileChooser : MonoBehaviour
{
    [SerializeField] private List<Tile> endTileAcceptedPositions;
    [SerializeField] private List<Tile> straightTileAcceptedPositions;
    [SerializeField] private List<Tile> curvedTileAcceptedPositions;
    [SerializeField] private List<Tile> threeWayTileAcceptedPositions;
    [SerializeField] private List<Tile> fourWayTileAcceptedPositions;
    [Space]
    [SerializeField] private GameObject endTile;
    [SerializeField] private GameObject straightTile;
    [SerializeField] private GameObject curvedTile;
    [SerializeField] private GameObject threeWayTile;
    [SerializeField] private GameObject fourWayTile;

    public Tile ChooseAcceptableRoadTile(Tile tile)
    {
        Tile result;
        List<Tile> acceptableTiles = new List<Tile>();
        foreach (Tile candidate in endTileAcceptedPositions)
        {
            if (MatchTile(tile, candidate))
            {
                Tile tmp = new Tile(candidate.top, candidate.bottom, candidate.right, candidate.left, candidate.rotation, endTile);
                acceptableTiles.Add(tmp);
            }
        }
        foreach (Tile candidate in straightTileAcceptedPositions)
        {
            if (MatchTile(tile, candidate))
            {
                Tile tmp = new Tile(candidate.top, candidate.bottom, candidate.right, candidate.left, candidate.rotation, straightTile);
                acceptableTiles.Add(tmp);
            }
        }
        foreach (Tile candidate in curvedTileAcceptedPositions)
        {
            if (MatchTile(tile, candidate))
            {
                Tile tmp = new Tile(candidate.top, candidate.bottom, candidate.right, candidate.left, candidate.rotation, curvedTile);
                acceptableTiles.Add(tmp);
            }
        }
        foreach (Tile candidate in threeWayTileAcceptedPositions)
        {
            if (MatchTile(tile, candidate))
            {
                Tile tmp = new Tile(candidate.top, candidate.bottom, candidate.right, candidate.left, candidate.rotation, threeWayTile);
                acceptableTiles.Add(tmp);
            }
        }
        foreach (Tile candidate in fourWayTileAcceptedPositions)
        {
            if (MatchTile(tile, candidate))
            {
                Tile tmp = new Tile(candidate.top, candidate.bottom, candidate.right, candidate.left, candidate.rotation, fourWayTile);
                acceptableTiles.Add(tmp);
            }
        }
        result = acceptableTiles[Random.Range(0, acceptableTiles.Count)];
        return result;
    }

    private bool MatchTile(Tile emptyTile, Tile candidate)
    {
        if (CheckIfMatchesOpening(emptyTile.bottom, candidate.bottom) && CheckIfMatchesOpening(emptyTile.top, candidate.top) && CheckIfMatchesOpening(emptyTile.right, candidate.right) && CheckIfMatchesOpening(emptyTile.left, candidate.left))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool CheckIfMatchesOpening(int empt, int cand)
    {
        if (empt == 0)
        {
            return true;
        }

        if (empt == 1 && cand == 1)
        {
            return true;
        }

        if (empt == -1 && cand == 0)
        {
            return true;
        }

        return false;
    }
}
