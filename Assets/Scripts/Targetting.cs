using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targetting : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] Transform enemy;
    [SerializeField] float shootRange = 20f;
    
    ParticleSystem arrows;
    // Start is called before the first frame update
    void Start()
    {
        //enemy = FindObjectOfType<Enemy>().transform;
        arrows = weapon.GetComponent<ParticleSystem>();
        
        
    }

    // Update is called once per frame
    void Update()
    {

        FindClosestEnemy();
        AimAtEnemy();

    }

    private void FindClosestEnemy()
    {
        EnemyLocator[] enemies = FindObjectsOfType<EnemyLocator>();
        Transform ClosestEnemy = null;
        float MaxEnemyDistance = Mathf.Infinity;

        foreach(EnemyLocator enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if(targetDistance < MaxEnemyDistance)
            {
                ClosestEnemy = enemy.transform;
                MaxEnemyDistance = targetDistance;
            }
        }

        enemy = ClosestEnemy;
    }

    private void AimAtEnemy()
    {

        float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

      weapon.LookAt(enemy);
        if ( targetDistance < shootRange)
        {

            ParticleAttack(true);

        }
        else
        {
            ParticleAttack(false);
        }
    }

    private void ParticleAttack(bool isActive)
    {
        var particleEmission = arrows.emission;
        particleEmission.enabled = isActive;  
    }
}
