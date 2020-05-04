using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] float movementPeriod = .5f;
    [SerializeField] ParticleSystem endZoneParticles;
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
            yield return new WaitForSeconds(movementPeriod); //TODO: SLOWED DOWN FOR TESTING
        }
        SelfDestruct();
    }
    //
    private void SelfDestruct()
    {
        Debug.Log("END ZONE");
        ParticleSystem temp_FXF = Instantiate(endZoneParticles, transform.position, 
                                                Quaternion.identity);
        temp_FXF.Play();
        Destroy(temp_FXF.gameObject, temp_FXF.main.duration);
        Destroy(gameObject);
    }
}
