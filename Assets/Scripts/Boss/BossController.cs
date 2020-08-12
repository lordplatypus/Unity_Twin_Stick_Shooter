using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : EnemyClass
{
    enum Phase
    {
        P1,
        P2,
    }
    enum State
    {
        ShootAtPlayer,
        ShootClockWise,
        ShootCounterClockWise,
    }
    Phase phase = Phase.P1;
    State state = State.ShootAtPlayer;
    Vector2 velocity;
    Vector2 position;    
    float vx;
    float vy;
    float angleToPlayer;
    Rigidbody2D playerRB;
    BossWeaponReference bwr;
    int count = 0;
    float cooldown = 0;

    // Start is called before the first frame update
    void Start()
    {
        health = 200;
        Speed = .5f;
        rb = GetComponent<Rigidbody2D>();
        playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        bwr = GetComponent<BossWeaponReference>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();
        if (phase == Phase.P1 && cooldown < Time.time) 
        {
            if (state == State.ShootAtPlayer)
            {
                ShootAtPlayer();
                count++;
                if (count >= 100) 
                {
                    state = State.ShootClockWise;
                    count = 0;
                }
            }
            else if (state == State.ShootClockWise)
            {
                ShootClockWise();
                count += 15;
                if (count >= 360) 
                {
                    state = State.ShootCounterClockWise;
                    count = 0;
                }
            }
            else if (state == State.ShootCounterClockWise)
            {
                ShootCounterClockWise();
                count -= 15;
                if (count <= -360) 
                {
                    state = State.ShootAtPlayer;
                    count = 0;
                }
            }
            cooldown = Time.time + .2f;
        }
    }

    void MoveToPlayer()
    {//All inputs are handled here
        angleToPlayer = MyMath.PointToPointAngle(rb.position.x, rb.position.y, 
            playerRB.position.x, playerRB.position.y);
        vx = Mathf.Cos(angleToPlayer) * Speed;
        vy = Mathf.Sin(angleToPlayer) * Speed;
        position = rb.position; //set player position to 'position'
        velocity = new Vector2(vx, vy); //set current player velocity to 'velocity'
        position += velocity * Time.fixedDeltaTime; //add velocity to position
        rb.MovePosition(position); //apply position update
    }

    void Phase1()
    {
        GameObject bossBullet = Instantiate(bwr.bossBullet, position, Quaternion.identity);
        bossBullet.GetComponent<BossBulletController>().SetPerameters(.001f,count * MyMath.Deg2Rad, 5);
        count += 15;
        if (count >= 360) count = 0;
    }

    void ShootAtPlayer()
    {
        GameObject bossBullet = Instantiate(bwr.bossBullet, position, Quaternion.identity);
        bossBullet.GetComponent<BossBulletController>().SetPerameters(.001f,angleToPlayer, 5);
    }

    void ShootClockWise()
    {
        GameObject bossBullet = Instantiate(bwr.bossBullet, position, Quaternion.identity);
        bossBullet.GetComponent<BossBulletController>().SetPerameters(.001f,count * MyMath.Deg2Rad, 5);
    }

    void ShootCounterClockWise()
    {
        GameObject bossBullet = Instantiate(bwr.bossBullet, position, Quaternion.identity);
        bossBullet.GetComponent<BossBulletController>().SetPerameters(.001f,count * MyMath.Deg2Rad, 5);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            TakeDamage(1);
            foundPlayer = true;
        }
    }
}
