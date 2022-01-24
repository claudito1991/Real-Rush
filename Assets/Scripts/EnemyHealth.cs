using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int enemyMaxHealth = 5;
    [SerializeField] int enemyCurrentHealth = 0;
    // Start is called before the first frame update
    void OnEnable()
    {
        enemyCurrentHealth = enemyMaxHealth;
    }

    private void OnParticleCollision(GameObject other)
    {
        enemyCurrentHealth--;
        Debug.Log("collision");
        if (enemyCurrentHealth<=0)
        {
            gameObject.SetActive(false);
        }
     
        
        
    }
}
