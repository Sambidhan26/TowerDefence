using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BankScript : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;

    [SerializeField] int currentBalance;
    public int CurrentBalance { get { return currentBalance; } }

    [SerializeField] Text goldText;


    private void Awake()
    {
        currentBalance = startingBalance;
        DisplayGold();
    }
    public void Deposite(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        DisplayGold();
    }

    public void WithDrawal(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        DisplayGold();
        if(currentBalance < 0)
        {
            //Game loss condition
            ReloadScene();
        }
    }

    void DisplayGold()
    {
        goldText.text = currentBalance.ToString();
    }

    void ReloadScene()
    {
        //SceneManager.LoadScene(0);
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
