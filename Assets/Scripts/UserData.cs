
using System;

[System.Serializable]
public class UserData
{
    public string UserID;
    public string Password;

    public string UserName;
    public int Cash;
    public int Balance;

    

    public UserData(string userID, string password,string userName, int cash, int balance)
    {
        UserID = userID;
        Password = password;

        UserName = userName;
        Cash = cash;
        Balance = balance;
    }
}
