using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] Vector2Int gridSize;

    [Tooltip("World Grid Size - Should match UnityEditor snap settings.")]
    [SerializeField] int unityGridSize = 10;
    public int UnityGridSize { get { return unityGridSize; } }

    Dictionary<Vector2Int, Nodes> grid = new Dictionary<Vector2Int, Nodes>();
    public Dictionary<Vector2Int,Nodes> Grid { get { return grid; } }

    private void Awake()
    {
        CreateGrid();
    }

    public Nodes GetNodes(Vector2Int coOrdinates)
    {
        if(grid.ContainsKey(coOrdinates))
        {
            return grid[coOrdinates];
        }

        return null;
    }

    void CreateGrid()
    {
        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                Vector2Int coOrdinates = new Vector2Int(x,y);
                grid.Add(coOrdinates, new Nodes(coOrdinates,true));

                //Debug.Log(grid[coOrdinates].coOrdinates + "=" + grid[coOrdinates].isWalkable);
            }
        }
    }
}
