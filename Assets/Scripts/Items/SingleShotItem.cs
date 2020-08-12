using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleShotItem : TheRootOfAllEvil
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && Wallet.money > 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponManager>().SetSingle();
            Wallet.UpdateWallet(-1);
            Kill();
        }
    }
}
