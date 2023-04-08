using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnTime = 1f;
    [SerializeField] int poolSize = 5;

    GameObject[] pool;

    private void Awake()
    {
        PopulatePool();

    }

    private void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy());   
    }
    void EnableObjectInPool()
        {
            for(int i = 0; i < pool.Length;i++)
            {
                if (pool[i].activeInHierarchy == false)
                {
                    pool[i].SetActive(true);
                    return;
                }
            }
        }

    IEnumerator spawnEnemy()
    {
        while (true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTime);
        }
    }

    

}
