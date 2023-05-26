using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using TMPro;
public class Bank : MonoBehaviour
{

    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance;
    [SerializeField] TextMeshProUGUI balanceText;
    public int CurrentBalance { get { return currentBalance; } }

    private void Awake()
    {
        currentBalance= startingBalance;
        updateBalanceTest();
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        updateBalanceTest();
    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        updateBalanceTest();

        if(currentBalance < 0)
        {
            ReloadScene();
        }

    }

    void updateBalanceTest()
    {
        balanceText.text= "Gold: " + currentBalance;
    }
    private static void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
