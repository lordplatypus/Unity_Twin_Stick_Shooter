using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstRifleItem : TheRootOfAllEvil
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && Wallet.money > 50)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponManager>().SetBurstRifle();
            Wallet.UpdateWallet(-50);
            Kill();
        }
    }
}
