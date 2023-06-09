using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 50;

    public bool CreateTower(Tower tower, Vector3 pos)
    {

        Bank bank = FindObjectOfType<Bank>();

        if (bank == null) { return false; }

        if (bank.CurrentBalance >=cost)
        {
            Instantiate(tower.gameObject, pos, Quaternion.identity);
            bank.Withdraw(cost);
            return true;
        }

        return false;
    }
}
