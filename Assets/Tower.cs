using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int towerCost = 75;
    public bool CreateTower(GameObject towerPrefab, Vector3 position, Quaternion rotation)
    {
        Bank bank = FindObjectOfType<Bank>();
        
        if(bank == null)
        {
            return false;
        }

        if(bank.CurrentBalance>=towerCost)
        {
            var turret = Instantiate(towerPrefab, position, rotation);
            turret.transform.Rotate(-90, 0, 0);
            bank.Withdraw(towerCost);
            return true;
        }

        return false;
    
    }
}
