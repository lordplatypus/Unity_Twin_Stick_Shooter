using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerDeathManager : MonoBehaviour
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
        if (PlayerController.health <= 0)
        {
            StartDeathCountDown();
        }

        if(end)
        {
            if (countDown<= Time.time) 
            {
                ResetPlayer();
                SceneController.GameScene();
            }
            else text.text = (countDown - Time.time).ToString();
        }
    }

    public void StartDeathCountDown()
    {
        end = true;
        countDown = Time.time + 3f;
    }

    void ResetPlayer()
    {
        Wallet.ResetWallet();
        Powerups.ResetPowerUps();
        WeaponManager.ResetWeapon();
        Round.ResetRound();
    }
}
