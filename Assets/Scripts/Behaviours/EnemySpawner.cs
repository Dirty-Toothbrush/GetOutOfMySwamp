using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;
    private void Awake()
    {
        //if the instance doesnt exists create it
        if (instance ==null)
        {
            instance = this;
        }
        else
        {   
            Destroy(this); // destroy excess instances
        }
    }

    public void SpawnEnemy(string enemyId, Path path)
    {
        WaveController.instance.AddToActiveEnemies();

        //TODO (FINAL BUILD): swap commented line to get prefabs from game manager

        GameObject enemyPrefab = TemporalLibrary.instance.enemyLibrary.GetPrefabByIdentificator(enemyId);
        //GameObject enemyPrefab = GameManager.instance.enemyLibrary.GetPrefabByIdentificator(enemyId);

        Instantiate(enemyPrefab, path.GetStep(0), Quaternion.identity).GetComponent<EnemyBehaviour>().SetInitialState(path);
    }
}
