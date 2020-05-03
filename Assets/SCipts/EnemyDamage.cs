using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] int hitPoints = 10;

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if(hitPoints <= 0)
        {
            KillEnemy();
        }
    }
    //
    private void ProcessHit()
    {
        hitPoints -= 1;
    }
    //
    private void KillEnemy()
    {
        Destroy(gameObject);
    }
}
