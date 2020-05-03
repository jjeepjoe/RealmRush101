using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower defenderTower;
    [SerializeField] Transform defenderContainer;
    Queue<Tower> towersQueue = new Queue<Tower>();
    //
    public void AddTower(WayPoint baseWaypoint)
    {
        int towerCount = towersQueue.Count;
        if(towerCount >= towerLimit)
        {
            MoveExistingTower(baseWaypoint);
        }
        else
        {
            CreateTower(baseWaypoint);
        }
    }
    //GET FIRST IN > CHANGE THE FLAGS > RESET THE TOWER IN QUEUE >
    //RESET THE SCREEN POSITION.
    private void MoveExistingTower(WayPoint newBaseWaypoint)
    {
        Debug.Log("WE ARE AT LIMIT");
        Tower  oldTower = towersQueue.Dequeue();
        oldTower.baseWayPoint.isPlaceable = true;
        newBaseWaypoint.isPlaceable = false;
        oldTower.baseWayPoint = newBaseWaypoint;
        oldTower.transform.position = newBaseWaypoint.transform.position;
        towersQueue.Enqueue(oldTower);
    }
    //MAKE ALL THE TOWERS
    private void CreateTower(WayPoint baseWaypoint)
    {
        Tower newTower = Instantiate(defenderTower,
                                baseWaypoint.transform.position,
                                Quaternion.identity
        );
        newTower.gameObject.transform.SetParent(defenderContainer);
        baseWaypoint.isPlaceable = false;
        newTower.baseWayPoint = baseWaypoint;
        towersQueue.Enqueue(newTower);
    }
}
