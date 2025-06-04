using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupBank : MonoBehaviour
{
    public GameObject depositPanel;
    public GameObject withdrawalPanel;
    public GameObject dW;
    public TextMeshProUGUI cashText;
    public TextMeshProUGUI balanceText;
    [Header("입금")]
    public GameObject customMoneyBtn;
    public TMP_InputField customMoneyInput;
    [Header("출금")]
    public GameObject customMoney;
    public TMP_InputField customMoneyInputt;
    [Header("잔액부족")]
    public GameObject error;
    public TextMeshProUGUI errorText;



    private void Start()
    {
        off();
        OffError();
        UpdateUIText();
    }

    public void ShowDeposit()
    {
        depositPanel.SetActive(true);
        withdrawalPanel.SetActive(false);
        dW.SetActive(false);
        UpdateUIText();
        

    }

    public void ShowWithdraw()
    {
        depositPanel.SetActive(false);
        withdrawalPanel.SetActive(true);
        dW.SetActive(false);
        UpdateUIText();
    }

    public void off()
    {
        depositPanel.SetActive(false);
        withdrawalPanel.SetActive(false);
        dW.SetActive(true) ;

        
    }

    public void DepositAmount(int amount)
    {
       var data = GameManager.Instance.userData;

        if(data.Cash >= amount)
        {
            data.Cash -= amount;
            data.Balance += amount;

            UIManager.Instance.Refresh();

            UpdateUIText();
        }
        else
        {
            ShowError();
        }
      
    }

    private void UpdateUIText()
    {
        if(cashText != null)
        {
            cashText.text = $"{GameManager.Instance.userData.Cash:N0}원";
        }
        if(balanceText != null)
        {
            balanceText.text = $"잔액 :   {GameManager.Instance.userData.Balance:N0}원";
        }
    }

    public void DepositCustom()
    {
        string text = customMoneyInput.text.Trim();

        int parsedAmount = 0;
        bool success = int.TryParse(text, out parsedAmount);


        var data = GameManager.Instance.userData;
        if(data.Cash >= parsedAmount)
        {
            data.Cash -= parsedAmount;
            data.Balance += parsedAmount;

            UIManager.Instance.Refresh();
            UpdateUIText();

            customMoneyInput.text = "";
        }
        else
        {
            ShowError();
        }

    }
    public void WithdrawAmount(int amount)
    {
        var data = GameManager.Instance.userData;

        if (data.Balance >= amount)
        {
            data.Cash += amount;
            data.Balance -= amount;

            UIManager.Instance.Refresh();

            UpdateUIText();
        }
        else
        {
            ShowError();
        }
       
    }
    public void WithdrawCustom()
    {
        string text = customMoneyInputt.text.Trim();

        int parsedAmount = 0;
        bool success = int.TryParse(text, out parsedAmount);


        var data = GameManager.Instance.userData;
        if (data.Balance >= parsedAmount)
        {
            data.Cash += parsedAmount;
            data.Balance -= parsedAmount;

            UIManager.Instance.Refresh();
            UpdateUIText();

            customMoneyInputt.text = "";
        }
        else
        {
            ShowError();
        }

    }
    public void ShowError()
    {              
        error.SetActive(true);
    }

    public void OffError()
    {   
       error.SetActive(false);       
    }
}
