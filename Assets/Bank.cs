using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBankBalance = 150;

    [SerializeField] int currentBalance;
    public int CurrentBalance { get { return currentBalance;  } }

    private void Awake()
    {
        currentBalance = startingBankBalance;
    }
    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
    }
}
