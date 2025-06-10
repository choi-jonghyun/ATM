using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupLogin : MonoBehaviour
{
    public GameObject loginPanel;

    public TMP_InputField idInputField;
    public TMP_InputField passwordInputField;

    public Button loginButton;


    public TextMeshProUGUI errorText;

    private void Awake()
    {            
            passwordInputField.contentType = TMP_InputField.ContentType.Password;
            passwordInputField.ForceLabelUpdate();
            errorText.gameObject.SetActive(false);
        
    }

    private void Start()
    {
        loginButton.onClick.AddListener(OnClickLogin);       
    }

    public void ShowLogin()
    {
        errorText.gameObject.SetActive(false);
        idInputField.text = "";
        passwordInputField.text = "";
        loginPanel.SetActive(true);
    }

    public void offLogin()
    {
        loginPanel.SetActive(false);
    }

    private void OnClickLogin()
    {
        string inputID = idInputField.text.Trim();
        string inputPW = passwordInputField.text.Trim();

        string filePath = Path.Combine(Application.persistentDataPath, inputID + ".json");

        if (!File.Exists(filePath))
        {
            ShowErrorMessage("등록된 계정 없음.");
            return;
        }

        string json = File.ReadAllText(filePath);
        UserData loaded = JsonUtility.FromJson<UserData>(json);

        if(loaded.Password != inputPW)
        {
            ShowErrorMessage("비밀번호 틀림");
            return;
        }

        GameManager.Instance.userData = loaded;
        GameManager.Instance.SaveUserData();

        offErrorMessage();
        offLogin();
        UIManager.Instance.Refresh();

        Debug.Log($"[PopupLogin] '{inputID}'로그인 성공");
    }

    

    private void ShowErrorMessage(string message)
    {
        errorText.text = message;
        errorText.gameObject.SetActive(true);
    }


    private void offErrorMessage()
    {
        errorText.gameObject.SetActive(false);
    }
    
}
