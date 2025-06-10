using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
 public static GameManager Instance;
    
 public UserData userData;

    private string path;
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        userData = new UserData("","","", 0, 0);

        path = Path.Combine(Application.persistentDataPath, "userdata.json");

        LoadUserData();
       

    }

    public void SaveUserData()
    {
        string json = JsonUtility.ToJson(userData, prettyPrint : true);
        File.WriteAllText(path, json);
        Debug.Log($"[GameManager] UserData가 JSON 파일에 저장. (경로 : {path})");
    }

    private void LoadUserData()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            userData =JsonUtility.FromJson<UserData>(json);
            Debug.Log($"[GameManager] JSON 파일에서 UserData를 불러옴. (경로: {path})");
        }
        else
        {
            SaveUserData();
        }

        UIManager.Instance.RefreshUI();

        PopupLogin popup = FindAnyObjectByType<PopupLogin>();
        if(popup != null&& string.IsNullOrEmpty(userData.UserID))
        {
            popup.ShowLogin();
        }
    }
}
