using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemReference : MonoBehaviour
{
    //Items
    public GameObject MoneyMagnetItem;
    public GameObject SeeEnemiesItem;
    public GameObject SeeMoneyItem;
    public GameObject BouncyBulletItem;
    public GameObject HealthItem;
    
    //Weapons
    public GameObject SingleShotItem;
    public GameObject SpreadShotItem;
    public GameObject UziItem;
    public GameObject BurstRifleItem;
    public GameObject BazookaItem;
    public GameObject BoomerangItem;
    public GameObject MineItem;

    //Money   
    public GameObject CoinItem;

    //Stuff
    static bool OneTimeSetUp = true;
    public static List<GameObject> ItemArray;

    void Start()
    {
        if (OneTimeSetUp)
        {
            RegularSetUp();
            if (ChallengeManager.SingleOnly) 
            {
                RemoveItemFromItemPoolTag("Weapon");
                ItemArray.Add(SingleShotItem);
            }
            if (ChallengeManager.OneHitDeath) RemoveItemFromItemPool("HealthItem");           
            OneTimeSetUp = false;
        }
    }

    void RegularSetUp()
    {
        ItemArray = new List<GameObject>() {
                SingleShotItem,
                SpreadShotItem,
                UziItem,
                MoneyMagnetItem,
                SeeEnemiesItem,
                SeeMoneyItem,
                BouncyBulletItem,
                BurstRifleItem,
                BazookaItem,
                BoomerangItem,
                MineItem,
                HealthItem
                };
    }

    public static void RemoveItemFromItemPool(string item)
    {
        ItemArray.RemoveAll(i => i.name == item);
    }

    public static void RemoveItemFromItemPoolTag(string tag)
    {
        ItemArray.RemoveAll(i => i.tag == tag);
    }
}
