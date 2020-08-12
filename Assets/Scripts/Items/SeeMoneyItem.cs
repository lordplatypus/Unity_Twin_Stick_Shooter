using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeMoneyItem : TheRootOfAllEvil
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && Wallet.money >= 20)
        {
            Powerups.SeeMoneyOnMinimap = true;
            Wallet.UpdateWallet(-20);
            Kill();
            ItemReference.RemoveItemFromItemPool("SeeMoneyOnMinimap");
        }
    }
}
