using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeEnemyItem : TheRootOfAllEvil
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && Wallet.money >= 60)
        {
            Powerups.SeeEnemiesOnMinimap = true;
            Wallet.UpdateWallet(-60);
            Kill();
            ItemReference.RemoveItemFromItemPool("SeeEnemyOnMinimap");
        }
    }
}
