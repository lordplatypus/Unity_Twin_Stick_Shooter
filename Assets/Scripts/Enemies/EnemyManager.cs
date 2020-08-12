using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    EnemyReference ef;
    EnemiesLeft el;
    public List<GameObject> enemies;
    int numOfEnemies = Round.enemyCount;

    void Start()
    {
        ef = GetComponent<EnemyReference>();
        el = GameObject.Find("Enemies Left").GetComponent<EnemiesLeft>();
        enemies = new List<GameObject>();
    }

    void Update()
    {
    }
    public void SpawnEnemies(int[,] map, int floorX, int floorY)
    {
        for(int i = 0; i < numOfEnemies; i++)
        {
            bool notDone = true;
            while(notDone)
            {
                int x = MyMath.Range(1, Round.width);
                int y = MyMath.Range(1, Round.height);
                float distanceToPlayer = Vector2.Distance(new Vector2(x, y), new Vector2(floorX, floorY));
                if (map[x, y] == 0 && distanceToPlayer > 10) 
                {
                    int randEnemy = MyMath.Range(0, 2);
                    if (randEnemy == 0) 
                    {
                        enemies.Add(Instantiate(ef.BasicEnemy, new Vector2(x + .5f, y + .5f), Quaternion.identity));
                        enemies[i].GetComponent<BasicEnemyController>().PassInfo(map);
                    }
                    else 
                    {
                        enemies.Add(Instantiate(ef.TeleportingEnemy, new Vector2(x + .5f, y + .5f), Quaternion.identity));
                        enemies[i].GetComponent<TeleportEnemyController>().PassInfo(map);
                    }

                    notDone = false;
                }
            }
        }
        el.EnemyCount(enemies.Count);
    }

    public void RemoveDeadEnemies()
    {
        enemies.RemoveAll(e => e == null);
        el.EnemyCount(enemies.Count - 1);
    }
}
