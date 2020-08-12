using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyBulletItem : TheRootOfAllEvil
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && Wallet.money >= 100)
        {
            Powerups.BouncyBullets = true;
            Wallet.UpdateWallet(-100);
            Kill();
            ItemReference.RemoveItemFromItemPool("BouncyBulletItem");
        }
    }
}
