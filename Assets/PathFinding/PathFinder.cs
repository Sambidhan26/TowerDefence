using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Vector2Int startCoordinates;
    [SerializeField] Vector2Int destinationCoordinates;

    Nodes startNode;
    Nodes destinationNodes;
    Nodes currentSearchNode;

    Queue<Nodes> frontier = new Queue<Nodes>();
    Dictionary<Vector2Int, Nodes> reached = new Dictionary<Vector2Int, Nodes>();

    Vector2Int[] directions = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down };

    GridManager gridManager;
    Dictionary<Vector2Int, Nodes> grid = new Dictionary<Vector2Int, Nodes>();

    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();

        if(gridManager != null)
        {
            grid = gridManager.Grid;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        startNode = gridManager.Grid[startCoordinates];
        destinationNodes = gridManager.Grid[destinationCoordinates];

        BreathFirstSearch();
        BuildPath();
    }

    //private void Update()
    //{
    //    ExploreNeighbours();
    //}

    void ExploreNeighbours()
    {
        List<Nodes> neighbours = new List<Nodes>();

        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighbourCoord = currentSearchNode.coOrdinates + direction;
            if(grid.ContainsKey(neighbourCoord))
            {
                neighbours.Add(grid[neighbourCoord]);
                //Debug.Log(grid[neighbourCoord]);
                //Debug.Log(grid[currentSearchNode.coOrdinates]);
                //Debug.Log(directions);

                //grid[neighbourCoord].isExplored = true;
                //grid[currentSearchNode.coOrdinates].isPath = true;

                
            }
        }

        foreach(Nodes neighbour in neighbours)
        {
            if(!reached.ContainsKey(neighbour.coOrdinates) && neighbour.isWalkable)
            {
                neighbour.connectedTo = currentSearchNode;
                reached.Add(neighbour.coOrdinates, neighbour);
                frontier.Enqueue(neighbour);
            }
        }
    }

    void BreathFirstSearch()
    {
        bool isRunning = true;

        frontier.Enqueue(startNode);
        reached.Add(startCoordinates,startNode);

        while(frontier.Count > 0 && isRunning)
        {
            currentSearchNode = frontier.Dequeue();
            currentSearchNode.isExplored = true;
            ExploreNeighbours();
            if(currentSearchNode.coOrdinates == destinationCoordinates)
            {
                isRunning = false;
            }
        }
    }

    List<Nodes>BuildPath()
    {
        List<Nodes> path = new List<Nodes>();

        Nodes currentNode = destinationNodes;

        path.Add(currentNode);
        currentNode.isPath = true;

        while(currentNode.connectedTo != null)
        {
            currentNode = currentNode.connectedTo;
            path.Add(currentNode);
            currentNode.isPath = true;
        }

        path.Reverse();
        return path;
    }
}
