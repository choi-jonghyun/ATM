
using System;

[System.Serializable]
public class UserData
{
    public string UserName;
    public int Cash;
    public int Balance;

    

    public UserData(string userName, int cash, int balance)
    {
        UserName = userName;
        Cash = cash;
        Balance = balance;
    }
}
