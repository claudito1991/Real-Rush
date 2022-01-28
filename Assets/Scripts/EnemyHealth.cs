using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(EnemyLocator))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int enemyMaxHealth = 5;
    [SerializeField] int enemyCurrentHealth = 0;
    [SerializeField] int difficultyRamp = 1;
    EnemyLocator enemyLocator;
    // Start is called before the first frame update
    void OnEnable()
    {
        enemyCurrentHealth = enemyMaxHealth;
        enemyLocator = GetComponent<EnemyLocator>();
    }

    private void OnParticleCollision(GameObject other)
    {
        enemyCurrentHealth--;
        Debug.Log("collision");
        if (enemyCurrentHealth<=0)
        {

            gameObject.SetActive(false);
            enemyMaxHealth += difficultyRamp;
            enemyLocator.GoldReward();
        }
     
        
        
    }
}
