using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    ItemReference ir;
    Vector2 position;
    // Start is called before the first frame update
    void Start()
    {
        ir = GetComponent<ItemReference>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomDropGenerator(Vector2 position)
    {
        // int num = MyMath.Range(0, 100);
        // if (num < 10) DropSingleShotItem(position);
        // else if (num < 20) DropSpreadShotItem(position);
        float num = MyMath.Range(0, 5) * ChallengeManager.multiplyer;
        DropCoinItem(position, (int)num);
    }

    void DropSingleShotItem(Vector2 position)
    {
        Instantiate(ir.SingleShotItem, position, Quaternion.identity);
    }

    void DropSpreadShotItem(Vector2 position)
    {
        Instantiate(ir.SpreadShotItem, position, Quaternion.identity);
    }

    void DropCoinItem(Vector2 position, int num)
    {
        for(int i = 0; i < num; i++)
        {
            Instantiate(ir.CoinItem, position, Quaternion.identity);
        }
    }
}
