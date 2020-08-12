using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Powerups
{
    public static float SpeedPowerup = 1;
    public static float ShootSpeedPowerup = 1;
    public static bool MoneyMagnet = false;
    public static bool SeeEnemiesOnMinimap = false;
    public static bool SeeMoneyOnMinimap = false;
    public static bool BouncyBullets = false;


    public static void ResetPowerUps()
    {
        SpeedPowerup = 1;
        ShootSpeedPowerup = 1;
        MoneyMagnet = false;
        SeeEnemiesOnMinimap = false;
        SeeMoneyOnMinimap = false;
        BouncyBullets = false;
    }
}
