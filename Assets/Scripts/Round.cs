using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Round
{
    public static int round = 1;
    public static int enemyCount = 10;
    public static int width = 50;
    public static int height = 50;

    public static void NextRound()
    {
        round++;
        enemyCount += 10;
        width += 5;
        height += 5;
    }

    public static void ResetRound()
    {
        round = 1;
        enemyCount = 10;
        width = 50;
        height = 50;
    }
}
