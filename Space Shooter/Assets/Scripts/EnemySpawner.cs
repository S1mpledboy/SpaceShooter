using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    float _enemySpawnRate = 0.5f;
    float _canSpawn = 0;
    [SerializeField]
    ObjectPooler _pooler;
    [SerializeField]
    float _enemySpawnOffsetRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > _canSpawn)
        {
            _canSpawn = Time.time + _enemySpawnRate;

            _pooler.SpawnFromPool("Enemy", transform.position, Random.Range(-1*_enemySpawnOffsetRange, _enemySpawnOffsetRange), 0f, 0f);

        }
    }
}
