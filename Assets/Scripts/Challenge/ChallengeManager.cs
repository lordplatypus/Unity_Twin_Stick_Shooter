using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ChallengeManager
{
    public static float multiplyer = 1;
    public static bool OneHitDeath = false;
    public static bool SingleOnly = false;

    public static void SetMultiplyer()
    {
        if (OneHitDeath) multiplyer *= 2;
        if (SingleOnly) multiplyer *= 2;
    }
}
