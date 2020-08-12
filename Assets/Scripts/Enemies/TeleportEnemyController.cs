using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportEnemyController : EnemyClass
{
    Vector2 velocity;
    Vector2 position;    
    float vx;
    float vy;
    float angleToPlayer;
    Rigidbody2D playerRB;
    int loseInterestCount = 180;
    bool lostVisual = false;
    bool dodge = false;
    Vector2 dodgeForce;
    int dodgeDelay;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        minimapIcon = GameObject.Find("Minimap Icon");
        if (Powerups.SeeEnemiesOnMinimap) minimapIcon.SetActive(true);
        else minimapIcon.SetActive(false);
        health = 3;
        Speed = 6f;
    }

    void Update()
    {
        if (lostVisual) loseInterestCount--;
        if (loseInterestCount <= 0) foundPlayer = false;
        if (dodgeDelay > 0) dodgeDelay--;

        if (foundPlayer) MoveToPlayer();
    }

    void FixedUpdate()
    {
        if (dodge) 
        {//dodge ability
            //add force to the rigidbody
            rb.AddForce(dodgeForce);
            //don't keep adding force
            dodge = false;
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

    public void Dodge(Vector2 bulletPosition)
    {
        float dodgeAngle;
        //get the angle of the incoming bullet
        float angleToBullet = MyMath.PointToPointAngle(rb.position.x, rb.position.y,
            bulletPosition.x, bulletPosition.y);
        //randomly choose to dodge left or right
        if (MyMath.Range(0, 2) == 0) dodgeAngle = -45f;
        else dodgeAngle = 45f;
        //caculate the force to move out of the away of the bullet
        dodgeForce = new Vector2(Mathf.Cos(angleToPlayer + dodgeAngle * MyMath.Deg2Rad) * .2f,
            Mathf.Sin(angleToPlayer + dodgeAngle * MyMath.Deg2Rad) * .2f);
        //turn on dodge ability
        dodge = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            foundPlayer = true;
            lostVisual = false;
            loseInterestCount = 180;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") lostVisual = true;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            TakeDamage(3);
        }
        if (other.gameObject.tag == "Bullet")
        {
            TakeDamage(1);
            foundPlayer = true;
        }
    }
}
