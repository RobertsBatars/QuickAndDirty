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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
