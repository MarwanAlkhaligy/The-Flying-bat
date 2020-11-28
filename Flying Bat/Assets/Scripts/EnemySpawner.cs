using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int numberOfEnmeies = 5;
    [SerializeField] private GameObject enemyPrefab = null;
    [SerializeField] private float minOffset = 0f, maxOffest = 0f;
    [SerializeField] private Transform[] enemySpawnPoints = null;
    private float tempTime = 0f;
    internal static int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        tempTime = Random.Range(minOffset, maxOffest); 
    }

    // Update is called once per frame
    void Update()
    {
        if(tempTime <= 0 && count < numberOfEnmeies) {
            GameObject enemy;
            if(enemySpawnPoints.Length > 0) {
                enemy = Instantiate(enemyPrefab, enemySpawnPoints[Random.Range(0, enemySpawnPoints.Length - 1)].position, Quaternion.identity);
            } else{
                enemy = Instantiate(enemyPrefab, Vector3.zero, Quaternion.identity);
            }
            tempTime = Random.Range(minOffset, maxOffest);
            count++;
        } else {
            tempTime -= Time.deltaTime;
        } 
    }
}
