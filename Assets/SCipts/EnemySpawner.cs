using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    //CONFIG PARAMS
    [Range(.1f,120f)]
    [SerializeField] float secondsBetweenSpawns = 5f;
    [SerializeField] EnemyMovement enemyPrefab;
    int enemyKillScore = 0;
    [SerializeField] Text killedScore;
    [SerializeField] AudioClip spawnedEnemySFX;

    private void Start()
    {
        killedScore.text = enemyKillScore.ToString();
        StartCoroutine(SpawnEnemy());
    }
    //
    private void Update()
    {
        killedScore.text = enemyKillScore.ToString();
    }
    //
    IEnumerator SpawnEnemy()
    {
        //NON-STOP SPAWNING
        while (true)
        {
            Instantiate(enemyPrefab, gameObject.transform);
            //GetComponent<AudioSource>().PlayOneShot(spawnedEnemySFX);
            yield return new WaitForSeconds(secondsBetweenSpawns);            
        }
    }
    public void CountUpKills()
    {
        enemyKillScore += 50;
    }
}
