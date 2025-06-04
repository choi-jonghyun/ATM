using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI BalanceText;
    public TextMeshProUGUI CashText;

    
    public void Refresh()
    {   UserData user = GameManager.Instance.userData;

        NameText.text = $"이름 :  {user.UserName}";
        BalanceText.text = $"잔액 :   {user.Balance}원";
        CashText.text = $"{user.Cash}원";
    }
    private void Start()
    {
        Refresh();
    }
}
