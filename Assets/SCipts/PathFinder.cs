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
    WayPoint searchCenter; //CURRENT SEARCH
    bool isRunning = true;
    //ARRAY USING PREDEFINED DIRECTIONS
    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };
    //OUR COLLECTION OF CONNECTIONS.
    List<WayPoint> path = new List<WayPoint>();

    //GETTER
    public List<WayPoint> GetPath()
    {
        if(path.Count == 0)
        {
            CalculatePath();
        }
        return path;
    }
    //REFACTORED
    private void CalculatePath()
    {
        LoadBlocks();
        //ColorStartAndEnd();
        BreadthFirstSearch();
        CreatePath();
    }
    //BREADCRUMBS
    private void CreatePath()
    {
        SetAsPath(endWayPoint);
        WayPoint previous = endWayPoint.exploredFrom;
        while(previous != startWayPoint)
        {
            SetAsPath(previous);
            previous = previous.exploredFrom;
        }
        SetAsPath(startWayPoint);
        path.Reverse();
    }
    //HELPER METHOD TO FLAG PATH BLOCKS USED.
    private void SetAsPath(WayPoint waypoint)
    {
        path.Add(waypoint);
        waypoint.isPlaceable = false;
    }
    //QUEUE WORK.
    private void BreadthFirstSearch()
    {
        queue.Enqueue(startWayPoint);
        while(queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            HaltIfEndFound();
            ExploreNeighbours();
            searchCenter.isExplored = true;
        }
    }
    //HELPER: CHECK FOR ENDPOINT
    private void HaltIfEndFound()
    {       
        if (searchCenter == endWayPoint)
        {
            isRunning = false;
        }
    }
    //EXPLORER AROUND TOP, RIGHT, BTM, LEFT AS SET IN OUR ARRAY.
    private void ExploreNeighbours()
    {
        if (!isRunning) { return; }
        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighbourCoordinates = searchCenter.GetGridPos() + direction;
            if(grid.ContainsKey(neighbourCoordinates))
            {
                QueueNewNeighbour(neighbourCoordinates);
            }            
        }
    }
    //FOUND A NEIGHBOUR > ADD HIM TO QUEUE.
    private void QueueNewNeighbour(Vector2Int neighbourCoordinates)
    {
        WayPoint neighbour = grid[neighbourCoordinates];
        //NOT EXPLORED AND NOT ALREADY IN QUEUE.
        if (!neighbour.isExplored && !queue.Contains(neighbour))
        {
            queue.Enqueue(neighbour);
            neighbour.exploredFrom = searchCenter;
        }
    }
    ////CHANGING THE TOP COLOR FOR START OR END POINT.
    //private void ColorStartAndEnd() //TODO add to waypoint?
    //{
    //    startWayPoint.SetTopColor(Color.green);
    //    endWayPoint.SetTopColor(Color.red);
    //}
    //WE COLLECT ALL OF THE GAMEOBJECTS IN THE HIERARCHY THAT ARE WAYPOINTS
    private void LoadBlocks()
    {
        var wayPoints = FindObjectsOfType<WayPoint>();
        foreach(WayPoint wayPoint in wayPoints)
        {
            //GET THE CONNECTION > CHECK FOR OVERLAP > ADD TO COLLECTION
            var gridPos = wayPoint.GetGridPos();
            if (!grid.ContainsKey(gridPos))
            {
                grid.Add(gridPos, wayPoint);
            }            
        }        
    }
}
