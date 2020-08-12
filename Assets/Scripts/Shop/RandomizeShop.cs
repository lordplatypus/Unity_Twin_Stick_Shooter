using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeShop : MonoBehaviour
{
    GameObject Shop;
    RandomShopGenerator rsg;
    bool oneTime = true;

    void Start()
    {
        Shop = GameObject.Find("Shop");
        rsg = Shop.GetComponent<RandomShopGenerator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && Wallet.money >= 50 && oneTime)
        {
            oneTime = false;
            GameObject[] items = GameObject.FindGameObjectsWithTag("Item");
            GameObject[] weapons = GameObject.FindGameObjectsWithTag("Weapon");

            foreach(GameObject i in items)
            {
                Destroy(i);
            }
            foreach(GameObject w in weapons)
            {
                Destroy(w);
            }

            rsg.SetUpShop();
            Wallet.UpdateWallet(-50);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            oneTime = true;
        }
    }
}
