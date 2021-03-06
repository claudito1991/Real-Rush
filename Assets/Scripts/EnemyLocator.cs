using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLocator : MonoBehaviour
{
    [SerializeField] int goldReward = 25;
    [SerializeField] int goldPenalty = 25;
    Bank bank;

    private void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    public void GoldReward()
    {
        if(bank == null) 
        {
            return;
        }
        bank.Deposit(goldReward);
    }

    public void StealGold()
    {
        if (bank == null)
        {
            return;
        }
        bank.Withdraw(goldPenalty);
    }
}
