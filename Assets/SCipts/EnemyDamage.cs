using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticleSystem;
    
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if(hitPoints <= 0)
        {
            ProcessDeath();
        }
    }
    //MY WAY WORKS FOR REFACTORING OUT JOBS > HIS SUGGESTION TO USE VARIABLE
    private void ProcessDeath()
    {
        deathParticleSystem.gameObject.SetActive(true);
        //var temp_vfx = Instantiate(deathParticleSystem, transform.position, 
        //                            Quaternion.identity);
        //temp_vfx.Play();
        //Destroy(temp_vfx.gameObject, temp_vfx.main.Duration)
        //SCORE IT UP
        FindObjectOfType<EnemySpawner>().CountUpKills();
        Destroy(gameObject, .5f);
    }
    //
    private void ProcessHit()
    {
        hitPoints -= 1;
        hitParticlePrefab.Play();
    }
}
