using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Wallet
{
    public static int money = 0;

    public static void UpdateWallet(int amount)
    {
        money += amount;
        CurrentMoney.UpdateMoney();
    }

    public static void ResetWallet()
    {
        money = 0;
    }
}
