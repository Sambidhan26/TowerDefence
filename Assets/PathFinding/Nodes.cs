using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Nodes
{
    public Vector2Int coOrdinates;

    public bool isWalkable;
    public bool isExplored;
    public bool isPath;

    public Nodes connectedTo;

    public Nodes(Vector2Int coOrdinates, bool isWalkable)
    {
        this.coOrdinates = coOrdinates;
        this.isWalkable = isWalkable;
    }
}
