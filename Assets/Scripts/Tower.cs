using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 50;
    public bool CreateTower(Tower tower, Vector3 position)
    {
        BankScript bank = FindObjectOfType<BankScript>();

        if (bank == null)
        {
            return false;
        }

        if (bank.CurrentBalance >= 0)
        {
            Instantiate(tower, position, Quaternion.identity);
            bank.WithDrawal(cost);
            return true;

        }

        return false;


    }
}
