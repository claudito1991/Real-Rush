using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] [Range(1, 40)] int poolsize = 30;
    [SerializeField] [Range(0.1f,30f)] float spawnTimer;
    [SerializeField] int waveSize = 10;
    GameObject[] pool;


    // Start is called before the first frame update
    void Start()
    {
        PopulateScene();
        StartCoroutine(SpawnEnemies());
    }

    void PopulateScene()
    {
        //Se crea y se inicializa el array según el tamaño del pool que deseamos
        pool = new GameObject[poolsize];

        // se loopea por todo el pool creando los enemigos y deshabilitandolos en la escena
        for(int i=0; i<pool.Length; i++)
        {
            pool[i] = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            pool[i].SetActive(false);
        }
    }

    
    IEnumerator SpawnEnemies()
    {
        int i = 0;
        while(i<10)
        {
         
         i++;
         EnableEnemyInPool();
         yield return new WaitForSeconds(spawnTimer);
        }
        
        
    }

    private void EnableEnemyInPool()
    {
        //Se loopea a través del pool chequeando si los enemigos están habilitados
        //Si no lo están se habilita uno y se rompe el loop, porque sino se activan todos a la vez
        foreach(GameObject enemy in pool)
        {
            if(!enemy.activeInHierarchy)
            {
                enemy.SetActive(true);
                return;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    
    }
}
