using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomShopGenerator : MonoBehaviour
{
    ItemReference ir;
    int width = 32;
    int height = 9;
    int num;
    bool selectionDone = false;
    int[] storeNum = new int[3] {-1, -1, -1};
    int i = 0;
    int x;
    int failsafe = 0;
    bool setUpShop = true;

    // Start is called before the first frame update
    void Start()
    {
        MyMath.Init();
        ir = GetComponent<ItemReference>();
        x = -width / 2 + 8;
    }

    // Update is called once per frame
    void Update()
    {
        if (setUpShop)  
        {
            bool sameNum = false;
            num = MyMath.Range(0, ItemReference.ItemArray.Count);
            foreach(int n in storeNum)
            {
                if (n == num) sameNum = true;
            }
            if (sameNum) 
            {
                failsafe++;
                if(failsafe >= 100) Destroy(this);
            }
            else
            {
                storeNum[i] = num;
                Instantiate(ItemReference.ItemArray[num], new Vector2(x + i * width/4, height / 2), Quaternion.identity);
                i++;
                if (i == 3) setUpShop = false;
            }   
        }     
    }

    public void SetUpShop()
    {
        setUpShop = true;
        storeNum = new int[3] {-1, -1, -1};
        i = 0;
        failsafe = 0;
    }   
}
