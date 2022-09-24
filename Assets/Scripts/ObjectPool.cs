using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefabs;

    GameObject[] pool; 
    [SerializeField][Range(0,50)] int poolSize = 5;

    [SerializeField] [Range(0.1f, 30f)] float spawnTimer = 1.0f; 

    private void Awake()
    {
        PopulatePool();


    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
        

    }

    // Update is called once per frame
    void Update()
    {
    }

    void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemyPrefabs, transform);
            pool[i].SetActive(false);
        }
    }

    void EnableObjectPool()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            if(pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            //Debug.Log("Hello There");
            EnableObjectPool();
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}
