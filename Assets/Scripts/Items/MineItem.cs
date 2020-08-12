using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineItem : TheRootOfAllEvil
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && Wallet.money >= 150)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponManager>().SetMine();
            Wallet.UpdateWallet(-150);
            Kill();
        }
    }
}
