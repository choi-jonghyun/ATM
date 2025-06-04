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

    public static UIManager Instance;
    public UserData userData;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void Refresh()
    {   UserData user = GameManager.Instance.userData;

        NameText.text = $"이름 :  {user.UserName}";
        BalanceText.text = $"잔액 :   {user.Balance:N0}원";
        CashText.text = $"{user.Cash:N0}원";
    }
    private void Start()
    {
        Refresh();
    }
}
