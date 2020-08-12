using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TheRootOfAllEvil : MonoBehaviour
{
    // //Items
    // public GameObject MoneyMagnetItem;
    // public GameObject SeeEnemiesItem;
    // public GameObject SeeMoneyItem;
    // public GameObject BouncyBulletItem;
    
    // //Weapons
    // public GameObject Bullet;
    // public GameObject SingleShotItem;
    // public GameObject SpreadShotItem;
    // public GameObject UziItem;
    // public GameObject BurstRifleItem;

    // //Money   
    // public GameObject CoinItem;

    // //Actors
    // public GameObject Player;
    // public GameObject Enemy;

    public virtual void Kill()
    {
        Destroy(gameObject);
    }
}
