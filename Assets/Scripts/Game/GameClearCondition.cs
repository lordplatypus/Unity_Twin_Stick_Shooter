using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameClearCondition : MonoBehaviour
{
    bool end = false;
    float countDown = 0;
    Text text;

    void Start()
    {
        text = GameObject.Find("End Count Down").GetComponent<Text>();
    }

    void Update()
    {
        if(end)
        {
            if (countDown<= Time.time) SceneController.ShopScene();
            else text.text = (countDown - Time.time).ToString();
        }
    }

    public void StartEndCountDown()
    {
        end = true;
        countDown = Time.time + 5f;
    }
}
