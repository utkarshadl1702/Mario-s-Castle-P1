using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Bank : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI displayBalance;
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance;

    void Awake()
    {
        currentBalance = startingBalance;
        displayBalance.text = startingBalance.ToString();
    }
    public int CurrentBalance() { return currentBalance; }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        UpdateDisplay();
    }
    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);


        if (currentBalance < 0)
        {
            //lose the game;
            ReloadScene();

        }
        UpdateDisplay();
    }

    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    void UpdateDisplay()
    {
        displayBalance.text = currentBalance.ToString();
    }
}
