using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UziItem : TheRootOfAllEvil
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && Wallet.money >= 100)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponManager>().SetUzi();
            Wallet.UpdateWallet(-100);
            Kill();
        }
    }
}
