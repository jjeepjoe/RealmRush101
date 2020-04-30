using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;

    //
    private void Update()
    {
        objectToPan.LookAt(targetEnemy);
    }
}
