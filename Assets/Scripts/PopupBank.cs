using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupBank : MonoBehaviour
{
    public GameObject depositPanel;
    public GameObject withdrawalPanel;
    public GameObject dW;

    private void Start()
    {
        off();
    }

    public void ShowDeposit()
    {
        depositPanel.SetActive(true);
        withdrawalPanel.SetActive(false);
        dW.SetActive(false);
        

    }

    public void ShowWithdraw()
    {
        depositPanel.SetActive(false);
        withdrawalPanel.SetActive(true);
        dW.SetActive(false);
    }

    public void off()
    {
        depositPanel.SetActive(false);
        withdrawalPanel.SetActive(false);
        dW.SetActive(true) ;
    }
}
