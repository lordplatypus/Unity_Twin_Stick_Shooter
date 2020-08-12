using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BazookaItem : TheRootOfAllEvil
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && Wallet.money >= 200)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponManager>().SetBazooka();
            Wallet.UpdateWallet(-200);
            Kill();
        }
    }
}
