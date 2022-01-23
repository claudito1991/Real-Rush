using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targetting : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] Transform enemy;
    ParticleSystem arrows;
    // Start is called before the first frame update
    void Start()
    {
        enemy = FindObjectOfType<Enemy>().transform;
        arrows = weapon.GetComponent<ParticleSystem>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy != null)
        {
            weapon.LookAt(enemy);

            if (!arrows.isPlaying)
            {
                arrows.Play();
            }

        }

    }
}
