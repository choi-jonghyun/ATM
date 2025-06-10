using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Remittance : MonoBehaviour
{
    public GameObject remittancePanel;          //송금 판넬
    public GameObject errorPanel;               //오류 판넬
    public TextMeshProUGUI errorPopupText;      //오류 텍스트
    public GameObject dW;
    

    public TMP_InputField targetInput;          //송금 대상
    public TMP_InputField amountInput;          //송금 금액 입력

    public Button cancelButton;
    public Button remittanceButton;
    public Button errorCloseButton;
    

    private void Awake()
    {
        remittancePanel.SetActive(false);
        errorPanel.SetActive(false);

        cancelButton.onClick.AddListener(OffRemittance);
        remittanceButton.onClick.AddListener(OnClickRemittance);
        errorCloseButton.onClick.AddListener(() => errorPanel.SetActive(false));
    }

    public void ShowRemittance()
    {
        ClearAllFields();
        dW.SetActive(false);
        remittancePanel.SetActive(true);
        
    }

    private void OffRemittance()
    {
        remittancePanel.SetActive(false);
        dW.SetActive(true);
    }

    private void OnClickRemittance()
    {
        string targetId = targetInput.text.Trim();
        string amountText = amountInput.text.Trim();

        if(string.IsNullOrEmpty(targetId) || string.IsNullOrEmpty(amountText))
        {
            ShowError("입력 정보를 확인해주세요.");
            return;
        }

        if ( !int.TryParse(amountText, out int amount) || amount <= 0)
        {
            ShowError("잔액이 부족합니다.");
            return;
        }

        string filePath = Path.Combine(Application.persistentDataPath, targetId + ".json");
        if (!File.Exists(filePath))
        {
            ShowError("대상이 없습니다.");
            return;
           
        }

        string json = File.ReadAllText(filePath);
        UserData targetData = JsonUtility.FromJson<UserData>(json);

        UserData myData = GameManager.Instance.userData;

        if(myData.Balance < amount)
        {
            ShowError("잔액이 부족합니다.");
            return;
        }

        myData.Balance -= amount;
        targetData.Balance += amount;

        SaveUserData(myData);
        SaveJson(targetData);

        GameManager.Instance.userData = myData;
        GameManager.Instance.SaveUserData();
        UIManager.Instance.Refresh();

        OffRemittance();
        Debug.Log($"[PopupRemittance] {targetId}에게 {amount}원 송금 완료");
    }
    private void  SaveJson(UserData data)
    {
        string json = JsonUtility.ToJson(data, prettyPrint: true);
        string file = Path.Combine(Application.persistentDataPath, data.UserID + ".json");
        File.WriteAllText(file, json);
        Debug.Log($"[PopupRemittance] 대상 계좌 JSON 저장: {file}");
    }
    private void SaveUserData(UserData data)
    {
        string json = JsonUtility.ToJson(data, prettyPrint: true);
        string file = Path.Combine(Application.persistentDataPath, "userdata.json");
        File.WriteAllText(file, json);
        Debug.Log($"[PopupRemittance] 내 계좌 JSON 저장: {file}");
    }

    private void ShowError(string message)
    {
        errorPopupText.text = message;
        errorPanel.transform.SetAsLastSibling();
        errorPanel.SetActive(true);
    }

    private void ClearAllFields()
    {
        targetInput.text = string.Empty;
        amountInput.text = string.Empty;
        errorPanel.SetActive(false);
    }


}
