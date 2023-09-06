using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy() {
        while(true) {
            Instantiate(enemyPrefab);
            yield return new WaitForSeconds(1);
        }
    }
}
