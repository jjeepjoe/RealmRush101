﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRange = 10f;
    [SerializeField] ParticleSystem projectileParticle;
    public WayPoint baseWayPoint; 
    //STATE OF THE TOWER
    Transform targetEnemy;

    //
    private void Update()
    {
        SetTargetEnemy();
        if (targetEnemy != null)
        {
            //THIS IS A TRANSFORM METHOD
            objectToPan.LookAt(targetEnemy);
            FireAtEnemy();
        }
        else
        {
            Shoot(false);
        }        
    }
    //RETURNS AN ARRAY OF ENEMIES > 
    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if(sceneEnemies.Length == 0) { return; }
        Transform closestEnemy = sceneEnemies[0].transform;
        foreach(EnemyDamage testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
        }
        targetEnemy = closestEnemy;
    }
    //CHOOSE THE ONE TO SHOOT
    private Transform GetClosest(Transform transformA, Transform transformB)
    {
        var distToA = Vector3.Distance(transform.position, transformA.position);
        var distToB = Vector3.Distance(transform.position, transformB.position);
        if(distToA < distToB)
        {
            return transformA;
        }
        return transformB;
    }
    //PULL THE TRIGGER
    private void FireAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position,
                                        gameObject.transform.position);
        if(distanceToEnemy <= attackRange)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }
    //ON/OFF TOGGLE
    private void Shoot(bool isActive)
    {
        var emissionModule = projectileParticle.emission;
        emissionModule.enabled = isActive;
    }
}
