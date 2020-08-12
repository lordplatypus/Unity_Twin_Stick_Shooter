using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : TheRootOfAllEvil
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && Wallet.money >= 50)
        {
            PlayerController.TakeDamage(-1);
            Wallet.UpdateWallet(-50);
            Kill();
        }
    }
}
