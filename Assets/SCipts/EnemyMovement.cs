﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //CONFIG PARAMS
    //[SerializeField] List<WayPoint> path; //TODO: remove
    //
    private void Start()
    {
        PathFinder pathfinder = FindObjectOfType<PathFinder>();
        var path = pathfinder.GetPath(); //debug point.
        StartCoroutine(FollowPath(path));
    }
    //PASSING IN THE LIST FOR THE ENEMY TO MOVE ON
    //WE ARE CHANGING THE ENEMY POSITION EVERY SECOND IN THE LIST ORDER.
    IEnumerator FollowPath(List<WayPoint> path)
    {
        foreach (WayPoint wayPoint in path)
        {
            transform.position = wayPoint.transform.position;
            yield return new WaitForSeconds(2f); //TODO: SLOWED DOWN FOR TESTING
        }
    }
}
