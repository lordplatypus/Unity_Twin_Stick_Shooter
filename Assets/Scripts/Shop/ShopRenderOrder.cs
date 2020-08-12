using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopRenderOrder : MonoBehaviour
{
    public GameObject player;
    RandomShopGenerator rsg;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(player, new Vector2(0, 0), Quaternion.identity);
        rsg = GameObject.Find("Shop").GetComponent<RandomShopGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        //rsg.SetUpShop();
        Destroy(this);
    }
}
