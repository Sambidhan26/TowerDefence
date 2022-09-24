using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    BankScript bank;

    [SerializeField] int goldReward = 25;
    [SerializeField] int goldPenalty = 25;
    // Start is called before the first frame update
    void Start()
    {
        bank = FindObjectOfType<BankScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RewardGold()
    {
        if(bank == null) { return; }
        bank.Deposite(goldReward);
    }

    public void StealGold()
    {
        if (bank == null) { return; }
        bank.WithDrawal(goldPenalty);
    }
}
 