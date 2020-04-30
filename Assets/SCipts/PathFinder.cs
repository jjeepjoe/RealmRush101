using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] WayPoint startWayPoint, endWayPoint;
    Dictionary<Vector2Int, WayPoint> grid = new Dictionary<Vector2Int, WayPoint>();
    //OUR DATA TYPE IS WAYPOINT SCRIPT
    Queue<WayPoint> queue = new Queue<WayPoint>();
    [SerializeField] bool isRunning = true; //TODO make private
    //USING PREDEFINED DIRECTIONS
    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    //
    private void Start()
    {
        LoadBlocks();
        ColorStartAndEnd();
        PathFind();
        //ExploreNeighbours();
    }
    //QUEUE WORK.
    private void PathFind()
    {
        queue.Enqueue(startWayPoint);
        while(queue.Count > 0)
        {
            var searchCenter = queue.Dequeue();
            Debug.Log("Searching from: " + searchCenter); //todo remove  
            HaltIfEndFound(searchCenter);
        }

        Debug.Log("Finished Pathfinding steps.");
    }
    //HELPER: CHECK FOR ENDPOINT
    private void HaltIfEndFound(WayPoint searchCenter)
    {
        if (searchCenter == endWayPoint)
        {
            Debug.Log("Searching from End point, stopping.");
            isRunning = false;
        }
    }
    //
    private void ExploreNeighbours()
    {
        foreach(Vector2Int direction in directions)
        {
            Vector2Int exploringCoordinates = startWayPoint.GetGridPos() + direction;
            Debug.Log("Exploring " + exploringCoordinates);
            try
            {
                grid[exploringCoordinates].SetTopColor(Color.blue);
            }
            catch(Exception ex)
            {
                Debug.Log(ex);
            }            
        }
    }
    //CHANGING THE TOP COLOR FOR START OR END POINT.
    private void ColorStartAndEnd()
    {
        startWayPoint.SetTopColor(Color.green);
        endWayPoint.SetTopColor(Color.red);
    }
    //WE COLLECT ALL OF THE GAMEOBJECTS IN THE HIERARCHY THAT ARE WAYPOINTS
    private void LoadBlocks()
    {
        var wayPoints = FindObjectsOfType<WayPoint>();
        foreach(WayPoint wayPoint in wayPoints)
        {
            //GET THE CONNECTION > CHECK FOR OVERLAP > ADD TO COLLECTION
            var gridPos = wayPoint.GetGridPos();
            if (grid.ContainsKey(gridPos))
            {
                Debug.Log("Skipping Overlapping Block: " + wayPoint);
            }
            else
            {
                //add to dictionary
                grid.Add(gridPos, wayPoint);
            }            
        }        
    }
}
