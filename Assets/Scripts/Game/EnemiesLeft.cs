using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesLeft : MonoBehaviour
{
    //EnemyManager em;
    Text text;
    public static int numOfEnemies;
    // Start is called before the first frame update
    void Start()
    {
        //em = GameObject.Find("Game").GetComponent<EnemyManager>();
        numOfEnemies = 0;
        text = GetComponent<Text>();
        text.text = "Enemies Left: " + numOfEnemies.ToString();
    }

    public void EnemyCount(int num)
    {
        numOfEnemies = num;
        text.text = "Enemies Left: " + numOfEnemies.ToString();
        if (numOfEnemies == 0 && PlayerController.health != 0)
        {
            GameObject.Find("Game").GetComponent<GameClearCondition>().StartEndCountDown();
            Round.NextRound();
        }
    }
}
