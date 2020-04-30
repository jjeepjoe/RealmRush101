using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] List<WayPoint> Path;
    //
    private void Start()
    {
        //StartCoroutine(FollowPath());
    }
    //WE ARE CHANGING THE ENEMY POSITION EVERY SECOND IN THE LIST ORDER.
    IEnumerator FollowPath()
    {
        Debug.Log("Starting Patrol.");
        foreach (WayPoint wayPoint in Path)
        {
            transform.position = wayPoint.transform.position;
            Debug.Log("Visiting Block: " + wayPoint.name);           
            yield return new WaitForSeconds(1f);
        }
        Debug.Log("Ending Patrol.");
    }
}
