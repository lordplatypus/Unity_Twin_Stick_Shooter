using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyMagnetItem : TheRootOfAllEvil
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && Wallet.money >= 50)
        {
            Powerups.MoneyMagnet = true;
            Wallet.UpdateWallet(-50);
            Kill();
            ItemReference.RemoveItemFromItemPool("MoneyMagnetItem");
        }
    }
}
