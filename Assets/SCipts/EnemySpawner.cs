using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] float secondsBetweenSpawns = 5f;
    [SerializeField] EnemyMovement enemyPrefab;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
    //
    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(secondsBetweenSpawns);
            Instantiate(enemyPrefab, gameObject.transform);
        }
    }
}
