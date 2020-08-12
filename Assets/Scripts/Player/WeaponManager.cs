using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    enum Weapon
    {
        Single,
        Spread,
        Uzi,
        BurstRifle,
        Bazooka,
        Boomerang,
        Mine,
        RedirectRifle,
    }
    WeaponReference wr;
    static Weapon weapon = Weapon.Single;
    Vector2 mousePosition;
    float angleToMouse;
    float cooldown = 0;
    float accuracy = 0;
    int accuracyCountDown = 10;
    int lag = 0;
    bool burstRifle = false;
    Vector2 position;
    //Weapon bought count
    static int singleCount = 99;
    // Start is called before the first frame update
    void Start()
    {
        wr = GetComponent<WeaponReference>();
    }

    public static void ResetWeapon()
    {
        weapon = Weapon.Single;
    }

    // Update is called once per frame
    void Update()
    {
        //Uzi
        if (accuracyCountDown > 0) accuracyCountDown--;
        if (accuracyCountDown <= 0) accuracy = 0;

        //BurstRifle
        if (burstRifle)
        {
            if (lag % 2 == 0)
            {
                GameObject bullet = Instantiate(wr.bullet, position, Quaternion.identity);
                float meh = MyMath.Range(-2, 2);
                bullet.GetComponent<BulletController>().SetPerameters(.05f, angleToMouse + meh * MyMath.Deg2Rad, 2);
            }
            lag++;
            if (lag >= 5)
            {
                lag = 0;
                burstRifle = false;
            }
        }
    }

    public void Shoot(Vector2 position)
    {
        if (cooldown <= Time.time)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            angleToMouse = MyMath.PointToPointAngle(position.x, position.y, 
                mousePosition.x, mousePosition.y);
            //position.x += Mathf.Cos(angleToMouse) * .3f;
            //position.y += Mathf.Sin(angleToMouse) * .3f;
            if (weapon == Weapon.Single)
            {
                Single(position);
            }
            else if (weapon == Weapon.Spread)
            {
                Spread(position);
            }
            else if (weapon == Weapon.Uzi)
            {
                Uzi(position);
            }
            else if (weapon == Weapon.BurstRifle)
            {
                BurstRifle(position);
            }
            else if (weapon == Weapon.Bazooka)
            {
                Bazooka(position);
            }
            else if (weapon == Weapon.Boomerang)
            {
                Boomerang(position);
            }
            else if (weapon == Weapon.Mine)
            {
                Mine(position);
            }
            else if (weapon == Weapon.RedirectRifle)
            {
                RedirectRifle(position);
            }
        }
    }

    void Single(Vector2 position)
    {
        GameObject bullet = Instantiate(wr.bullet, position, Quaternion.identity);
        bullet.GetComponent<BulletController>().SetPerameters(.05f, angleToMouse, 1);       
        cooldown = Time.time + .2f;

        if (singleCount >= 100)
        {
            for (int i = 0; i < 360; i = i + 10)
            {
                bullet = Instantiate(wr.bullet, position, Quaternion.identity);
                bullet.GetComponent<BulletController>().SetPerameters(.05f, angleToMouse + i * MyMath.Deg2Rad, 1); 
            }
        }
    }

    public void SetSingle()
    {
        weapon = Weapon.Single;
        singleCount++;
    }

    void Spread(Vector2 position)
    {
        GameObject bullet = Instantiate(wr.bullet, position, Quaternion.identity);
        bullet.GetComponent<BulletController>().SetPerameters(.05f, angleToMouse, 1);
        bullet = Instantiate(wr.bullet, position, Quaternion.identity);
        bullet.GetComponent<BulletController>().SetPerameters(.05f, angleToMouse + 10 * MyMath.Deg2Rad, 1);
        bullet = Instantiate(wr.bullet, position, Quaternion.identity);
        bullet.GetComponent<BulletController>().SetPerameters(.05f, angleToMouse - 10 * MyMath.Deg2Rad, 1);      
        cooldown = Time.time + .2f;
    }

    public void SetSpread()
    {
        weapon = Weapon.Spread;
    }

    void Boomerang(Vector2 position)
    {
        GameObject bullet = Instantiate(wr.bullet, position, Quaternion.identity);
        bullet.GetComponent<BulletController>().SetPerametersRedirection(.05f, .05f * 2, angleToMouse, angleToMouse - MyMath.PI, 1);
        cooldown = Time.time + .2f;
    }

    public void SetBoomerang()
    {
        weapon = Weapon.Boomerang;
    }

    void Uzi(Vector2 position)
    {
        GameObject bullet = Instantiate(wr.bullet, position, Quaternion.identity);
        float meh = MyMath.Range(-accuracy, accuracy);
        bullet.GetComponent<BulletController>().SetPerameters(.05f, angleToMouse + meh * MyMath.Deg2Rad, .5f);
        accuracy++;
        accuracyCountDown = 10;
        cooldown = Time.time + .05f;
    }

    public void SetUzi()
    {
        weapon = Weapon.Uzi;
    }

    void BurstRifle(Vector2 position)
    {
        this.position = position;
        burstRifle = true;
        cooldown = Time.time + .5f;
    }

    public void SetBurstRifle()
    {
        weapon = Weapon.BurstRifle;
    }

    void Bazooka(Vector2 position)
    {
        GameObject bullet = Instantiate(wr.bullet, position, Quaternion.identity);
        bullet.GetComponent<BulletController>().SetPerametersExplosion(.05f, angleToMouse, 1);       
        cooldown = Time.time + .7f;
    }

    public void SetBazooka()
    {
        weapon = Weapon.Bazooka;
    }

    void Mine(Vector2 position)
    {
        GameObject bullet = Instantiate(wr.bullet, position, Quaternion.identity);
        bullet.GetComponent<BulletController>().SetPerametersExplosion(0f, angleToMouse, 1);       
        cooldown = Time.time + .7f;
    }

    public void SetMine()
    {
        weapon = Weapon.Mine;
    }

    void RedirectRifle(Vector2 position)
    {
        GameObject bullet = Instantiate(wr.bullet, position, Quaternion.identity);
        float randomAngle = MyMath.Range(0, 360) * MyMath.Deg2Rad;
        bullet.GetComponent<BulletController>().SetPerametersRedirection(.05f, .05f, angleToMouse, randomAngle, 1);
        cooldown = Time.time + .2f;
    }

    public void SetRedirectRifle()
    {
        weapon = Weapon.RedirectRifle;
    }
}
