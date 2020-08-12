using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangItem : TheRootOfAllEvil
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && Wallet.money >= 80)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponManager>().SetBoomerang();
            Wallet.UpdateWallet(-80);
            Kill();
        }
    }
}
