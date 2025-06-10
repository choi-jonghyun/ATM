using System.Collections;
using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupSignup : MonoBehaviour
{
    public GameObject signUpPanel;
    public GameObject errorPopupPanel;
    public TextMeshProUGUI errorPopupText;
    public Button errorPopupCloseButton;

    public TMP_InputField idInput;
    public TMP_InputField nameInput;
    public TMP_InputField psInput;
    public TMP_InputField psConfirmInput;

    public Button cancelButton;
    public Button signUpButton;

    private const int DefaultCash = 100000;
    private const int DefaultBalance = 100000;

    private void Awake()
    {
        signUpPanel.SetActive(false);
        errorPopupPanel.SetActive(false);

        psInput.contentType = TMP_InputField.ContentType.Password;
        psConfirmInput.contentType = TMP_InputField.ContentType.Password;
        psInput.ForceLabelUpdate();
        psConfirmInput.ForceLabelUpdate();

        cancelButton.onClick.AddListener(OffSignUp);
        signUpButton.onClick.AddListener(OnClickSignUp);
        errorPopupCloseButton.onClick.AddListener(() => errorPopupPanel.SetActive(false));

        
    }

    public void ShowSignUp()
    {
        ClearAllFields();
        signUpPanel.SetActive(true);
    }

    private void OffSignUp()
    {
        signUpPanel.SetActive(false);
    }

    private void OnClickSignUp()
    {
        string id = idInput.text.Trim();
        string name = nameInput.text.Trim();
        string ps = psInput.text.Trim();
        string psConfirm = psConfirmInput.text.Trim();

        if(string.IsNullOrEmpty(id) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(ps) || string.IsNullOrEmpty(psConfirm))
        {
            ShowError("모든 항목 입력");
            return;
        }

        if ( ps != psConfirm)
        {
            ShowError("비밀번호 틀림!");
            return;
        }

        string filePath = Path.Combine(Application.persistentDataPath, id + ".json");
        if (File.Exists(filePath))
        {
            ShowError("이미 존재하는 아이디");
            return;
        }

        UserData newUser = new UserData(id, ps, name, DefaultCash, DefaultBalance);

        SaveWithJson(newUser);

        OffSignUp();
        Debug.Log($"[PopupSignUp] 가입 완료 : {id}");
    }

    private void SaveWithJson(UserData data)
    {
        string json = JsonUtility.ToJson(data, prettyPrint: true);
        string file = Path.Combine(Application.persistentDataPath, data.UserID + ".json");
        File.WriteAllText(file, json);
        Debug.Log($"[PopupSignUp] JSON 저장 :{file}");
    }

    private void ShowError(string message)
    {
        errorPopupText.text = message;
        errorPopupPanel.transform.SetAsLastSibling();
        errorPopupPanel.SetActive(true);
    }

    private void ClearAllFields()
    {
        idInput.text = string.Empty;
        nameInput.text = string.Empty;
        psInput.text = string.Empty;
        psConfirmInput.text = string.Empty;
        errorPopupPanel.SetActive(false);
    }
}
