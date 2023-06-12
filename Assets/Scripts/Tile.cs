using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Tile
{
    public int top = 0;
    public int bottom = 0;
    public int right = 0;
    public int left = 0;
    public float rotation = 0;
    public GameObject tile;

    public Tile(int top, int bottom, int right, int left, float rotation, GameObject tile)
    {
        this.top = top;
        this.bottom = bottom;
        this.right = right;
        this.left = left;
        this.rotation = rotation;
        this.tile = tile;
    }

    public Tile()
    {

    }
}
