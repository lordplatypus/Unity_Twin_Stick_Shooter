using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentMoney : MonoBehaviour
{
    static Text text;
    
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.text = "Money: " + Wallet.money.ToString();
    }

    public static void UpdateMoney()
    {
        text.text = "Money: " + Wallet.money.ToString();
    }
}
