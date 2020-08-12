using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadShotItem : TheRootOfAllEvil
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && Wallet.money >= 30)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponManager>().SetSpread();
            Wallet.UpdateWallet(-30);
            Kill();
        }
    }
}
